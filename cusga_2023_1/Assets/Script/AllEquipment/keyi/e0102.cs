using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0102: MonoBehaviour
{


    public BagList myBag;
    public bool isdelDefence=true;//是否扣除防御值
    public bool isdogle;//是否冲刺状态
    // Update is called once per frame
    public void f0102()
    {
             if(isdogle)
                isdelDefence = false;//不扣防御值
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //if (myBag.itemList.Find(z => z.itemName.Contains("0102")))//携带了这件装备
           

        }
    }
    }

