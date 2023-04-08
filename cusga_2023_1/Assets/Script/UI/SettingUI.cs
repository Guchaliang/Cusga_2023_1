using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SettingUI : UIBase
{
    private void Awake()
    {
        Register("Btns/backButton").onClick = onCloseBtn;
    }

    private void onCloseBtn(GameObject obj, PointerEventData data)
    {
        Close();
    }
}
