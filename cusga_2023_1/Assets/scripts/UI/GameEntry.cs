using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEntry : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
        UIManager.Instance.ShowUI<LoginUI>("LoginUI");
    }
}
