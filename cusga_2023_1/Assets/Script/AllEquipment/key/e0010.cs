using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0010 : MonoBehaviour
{
    public bool isHit;//是否为受击状态
    public bool isavoidHit;//是否免伤
    public BagList myBag;
    public float x;
    public float y;//免伤概率
    public bool key;//装备开关
    
    // Update is called once per frame
    void Update()
    {
       x= Random.Range(1, 10000);
        if (myBag.itemList.Find(z => z.itemName.Contains("0010")))
        {
            if (isHit)//受击状态
            {
                if (x  <y*10000)
                {
                    isavoidHit = true;
                }
                else
                    isavoidHit= false;
            }
        }
    }
}
