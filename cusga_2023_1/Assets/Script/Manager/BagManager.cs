using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagManager : Singleton<BagManager>
{
    public BagList myBag;
    public GameObject slotGrid;
    public SlotBag slot;
    public Text itemText;

    private void OnEnable()
    {
        if (myBag != null)//清空背包数据中的获取装备
        {
            myBag.itemList.Clear();
        }
        itemText.text = " ";
    }
}
