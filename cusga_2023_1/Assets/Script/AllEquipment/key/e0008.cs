using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0008 : MonoBehaviour
{
    public storeData storeData;
    public float discount;//商品优惠力度
    public float addcount;//卖出装备额外收益
    public void f0008()
    {
        for (int i = 0; i < storeData.commodityList.Count; i++)
        {
            storeData.commodityList[i].commodityprice *= addcount;
            storeData.commodityList[i].commoditycost *= discount;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            f0008();

        }
    }
}
