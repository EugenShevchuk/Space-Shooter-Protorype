using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public GameObject defaultPrefab;

    private GameObject _playerPrefab = HangarCosmetics.chosenPrefab;
    private Material _playerMaterial = HangarCosmetics.chosenMaterial;

    private GameObject _player;

    private void Start()
    {
        if (_playerPrefab != null)
        {
            _player = Instantiate(_playerPrefab);
            // Костыль создающий массив дочерних элементов, после чего, с помощью цикла присваивающий каждому элементу материал.
            MeshRenderer[] childRenderers = _player.GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < childRenderers.Length; i++)
            {
                childRenderers[i].material = _playerMaterial;
            }
        }
        else
        {
            _player = Instantiate(defaultPrefab);
        }

        _player.GetComponent<PlayerController>().enabled = true;
        _player.GetComponent<OpenFire>().enabled = true;
        _player.transform.Find("Shield").gameObject.SetActive(true);        
        _player.tag = "Player";
        _player.layer = LayerMask.NameToLayer("Player");
    }
}
