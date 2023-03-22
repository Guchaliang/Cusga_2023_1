using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Camera myCamera;
    public PlayerTest playerPrefab;

    [HideInInspector] public PlayerTest player;

    private void Start()
    {
        SetPlayerActive();
    }

    public void SetPlayerActive()
    {
        player = Instantiate(playerPrefab);
    }
}