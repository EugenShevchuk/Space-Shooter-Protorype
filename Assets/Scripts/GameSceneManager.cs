using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public GameObject[] playerPrefabs;

    private GameObject _player;

    private void Start()
    {
        // ������� ������, �������� ��������������� ������ � ����������� ���+����.
        _player = Instantiate(playerPrefabs[0]);
        _player.GetComponent<PlayerController>().enabled = true;
        _player.transform.Find("Shield").gameObject.SetActive(true);        
        _player.tag = "Player";
        _player.layer = LayerMask.NameToLayer("Player");
    }
}
