using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0008 : MonoBehaviour
{
    public storeData storeData;
    public float discount;//��Ʒ�Ż�����
    public float addcount;//����װ����������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            for (int i = 0; i < storeData.commodityList.Count; i++)
            {
                storeData.commodityList[i].commodityprice *= addcount;
                storeData.commodityList[i].commoditycost *= discount;
                Debug.Log("1");
            }

        }
    }
}