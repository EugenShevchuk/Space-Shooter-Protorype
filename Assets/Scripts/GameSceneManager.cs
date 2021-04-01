using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public GameObject[] playerPrefabs;

    private void Start()
    {
        Instantiate(playerPrefabs[0]);        
    }
}
