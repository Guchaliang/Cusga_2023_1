using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0102: MonoBehaviour
{


    public BagList myBag;
    public bool isdelDefence=true;//�Ƿ�۳�����ֵ

    // Update is called once per frame
    void Update(){

            if (myBag.itemList.Find(z => z.itemName.Contains("0102")))//Я�������װ��
                
                    isdelDefence = false;//���۷���ֵ
   
        }
    }

