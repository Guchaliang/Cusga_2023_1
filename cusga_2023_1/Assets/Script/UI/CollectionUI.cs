using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CollectionUI : UIBase
{
    private void Awake()
    {
        Register("Btns/backButton").onClick = onCloseBtn;
        Register("Btns/godsButton").onClick = onGodsButton;
        Register("Btns/propsButton").onClick = onPropsButton;
    }

    private void onCloseBtn(GameObject obj, PointerEventData data)
    {
        Close();
    }    
    private void onGodsButton(GameObject obj, PointerEventData data)
    {
        Close();
        UIManager.Instance.ShowUI<CollectionDeitiesUI>("CollectionDeitiesUI");
    }    
    private void onPropsButton(GameObject obj, PointerEventData data)
    {
        Close();
        UIManager.Instance.ShowUI<CollectionDeitiesUI>("CollectionDeitiesUI");
    }
}

