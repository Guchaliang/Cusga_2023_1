using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0010 : MonoBehaviour
{
    public bool isHit;//�Ƿ�Ϊ�ܻ�״̬
    public bool isavoidHit;//�Ƿ�����
    public BagList myBag;
    public float x;
    public float y;//���˸���
    public bool key;//װ������
    
    // Update is called once per frame
    void Update()
    {
       x= Random.Range(1, 10000);
        if (myBag.itemList.Find(z => z.itemName.Contains("0010")))
        {
            if (isHit)//�ܻ�״̬
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
