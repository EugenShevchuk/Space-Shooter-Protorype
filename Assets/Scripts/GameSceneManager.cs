using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    private GameObject _playerPrefab = Singleton.Singleton.playerPrefab;
    private Material _playerMaterial = Singleton.Singleton.playerMaterial;

    private GameObject _player;

    private void Start()
    {
        _player = Instantiate(_playerPrefab);
        // Костыль создающий массив дочерних элементов, после чего, с помощью цикла присваивающий каждому элементу материал.
        MeshRenderer[] childRenderers = _player.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < childRenderers.Length; i++)
        {
            childRenderers[i].material = _playerMaterial;
        }

        _player.GetComponent<PlayerController>().enabled = true;
        _player.transform.Find("Shield").gameObject.SetActive(true);        
        _player.tag = "Player";
        _player.layer = LayerMask.NameToLayer("Player");
    }
}
