using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BagUI : UIBase
{
    public BagList myBag;
    public GameObject slotGrid;
    public SlotBag slot;
    public Text itemText;

    private void Awake()
    {
        Register("Btns/CloseBtn").onClick = OnCloseBtn;
    }

    private void OnCloseBtn(GameObject arg1, PointerEventData arg2)
    {
        Debug.Log("1");
        Close();
    }

    public void UpdateItemText(string itemTxt)
    {
        itemText.text = itemTxt;
    }
    public void CreateNewItem(Itemm item)
    {
        SlotBag newitem = Instantiate(slot, slotGrid.transform.position, Quaternion.identity);
        newitem.gameObject.transform.SetParent(slotGrid.transform);
        newitem.slotItem = item;
        newitem.slotImage.sprite = item.itemImage;
    }
}
