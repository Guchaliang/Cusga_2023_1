using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0102: MonoBehaviour
{


    public BagList myBag;
    public bool isdelDefence=true;//�Ƿ�۳�����ֵ
    public bool isdogle;//�Ƿ���״̬
    // Update is called once per frame
    public void f0102()
    {
             if(isdogle)
                isdelDefence = false;//���۷���ֵ
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //if (myBag.itemList.Find(z => z.itemName.Contains("0102")))//Я�������װ��
           

        }
    }
    }

