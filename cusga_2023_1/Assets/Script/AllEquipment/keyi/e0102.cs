using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0102: MonoBehaviour
{


    public BagList myBag;
    public bool isdelDefence=true;//是否扣除防御值

    // Update is called once per frame
    void Update(){

            if (myBag.itemList.Find(z => z.itemName.Contains("0102")))//携带了这件装备
                
                    isdelDefence = false;//不扣防御值
   
        }
    }

