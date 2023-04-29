using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BagUI : UIBase
{
    public BagList myBag;
    //װ��ͼ��
    public GameObject slotGrid;
    public GameObject equip;
    public SlotBag slot;
    public Text itemText;
    public Itemm curItem;

    private void Awake()
    {
        Register("Btns/CloseBtn").onClick = OnCloseBtn;
        Register("Btns/UnloadBtn").onClick = OnUnloadBtn;

        //��ձ��������еĻ�ȡװ��
        if (myBag != null)
        {
            myBag.itemList.Clear();
        }
        itemText.text =" ";

    }

    private void OnUnloadBtn(GameObject arg1, PointerEventData arg2)
    {
        if (!curItem)
            return;
        equip.GetComponent<destroyEquipment>().bagList_sub(curItem.itemName);
        GameObject newObj= GameObject.Find(curItem.itemName);
        Destroy(newObj);
    }

    private void OnCloseBtn(GameObject arg1, PointerEventData arg2)
    {
        Close();
        Time.timeScale = 1;
    }

    public void UpdateItemText(string itemTxt)
    {
        itemText.text = itemTxt;
    }

    public void UpdateCurItem(Itemm item)
    {
        equip = GameObject.FindGameObjectWithTag("Equipment");
        curItem = item;
    }

    public void CreateNewItem(Itemm item)
    {
        SlotBag newitem = Instantiate(slot, slotGrid.transform.position, Quaternion.identity);
        newitem.gameObject.transform.SetParent(slotGrid.transform);
        newitem.slotItem = item;
        newitem.slotImage.sprite = item.itemImage;
        newitem.name = item.itemName;
    }

    public void UpdateAttribute()
    {

    }
}
