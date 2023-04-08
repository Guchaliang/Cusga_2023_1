using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentUI : UIBase
{
    public List<Item> bagList = new List<Item>();
    private void Awake()
    {
        Register("PlayerUI/CloseBtn").onClick = onCloseBtn;
       
    }

    private void onCloseBtn(GameObject obj, PointerEventData data)
    {
        Close();
        Time.timeScale = 1;       
    }

}
