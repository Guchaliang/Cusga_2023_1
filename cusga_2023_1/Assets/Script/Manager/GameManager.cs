using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public CinemachineConfiner cinemachineConfiner;

    private void Start()
    {
        cinemachineConfiner = FindObjectOfType<CinemachineConfiner>();
    }
}