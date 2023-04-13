using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : Singleton<GameManager>
{
    public Camera myCamera;
    public PlayerTest playerPrefab;
    public List<GameObject> enemyList;
    public List<GameObject> itemList;

    [HideInInspector] public PlayerTest player;

    private void Start()
    {
        SetPlayerActive();
    }

    public void SetPlayerActive()
    {
        player = Instantiate(playerPrefab);
    }

    public GameObject GetEenmyRandomly()
    {
        return enemyList[Random.Range(0,2)];
    }
}