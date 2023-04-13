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
        if (myBag != null)//��ձ��������еĻ�ȡװ��
        {
            myBag.itemList.Clear();
        }
        itemText.text = " ";
    }
}
