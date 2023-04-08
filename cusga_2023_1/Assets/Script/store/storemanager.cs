using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public  class storemanager : MonoBehaviour
{
    static storemanager instance;
    public storeData store;
    public GameObject slotGrid;
    public SlotStore slot;
    public Text itemText;

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
        
        //无需清空数据中有装备最好
    }

    private void OnEnable()
    {
        instance.itemText.text = " ";
    }

    public static void UpdateItemText(string itemTxt)
    {
        instance.itemText.text = itemTxt;
    }

    public static void CreateNewItem(commodity item)
    {
        
        SlotStore newitem = Instantiate(instance.slot, instance.slotGrid.transform.position, Quaternion.identity);
        newitem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newitem.slotItem = item;
        newitem.slotImage.sprite = item.commodityImage;
    }
}
