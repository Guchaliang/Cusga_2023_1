using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class BagMangaer : MonoBehaviour
{
    static BagMangaer instance;

    public BagList myBag;
    public GameObject slotGrid;
    public SlotBag slot;
    public Text itemText;

    private void Awake()
    {
        if(instance != null)
            Destroy(this);
        instance = this;
        if(myBag != null)//清空背包数据中的获取装备
        {
            myBag.itemList.Clear();
        }
    }

    private void OnEnable()
    {
        instance.itemText.text = " ";
    }

    public static void UpdateItemText(string itemTxt)
    {
        instance.itemText.text = itemTxt;
    }

    public static void CreateNewItem(Itemm item)
    {

        SlotBag newitem = Instantiate(instance.slot,instance.slotGrid.transform.position,Quaternion.identity);
        newitem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newitem.slotItem = item;
        newitem.slotImage.sprite = item.itemImage;
    }
}
