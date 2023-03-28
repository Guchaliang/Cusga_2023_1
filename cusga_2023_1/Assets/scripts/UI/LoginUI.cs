using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LoginUI : UIBase
{
    private void Awake()
    {
        Register("Btns/StartBtn").onClick = onStartBtn;      
        Register("Btns/QuitBtn").onClick = onQuitBtn;      
    }

    private void onStartBtn(GameObject obj, PointerEventData data)
    {
        Close();
        Time.timeScale = 1;

        //SceneManager.LoadScene("GameScene");
    }

    private void onQuitBtn(GameObject obj, PointerEventData data)
    {
        Application.Quit();
    }
}
