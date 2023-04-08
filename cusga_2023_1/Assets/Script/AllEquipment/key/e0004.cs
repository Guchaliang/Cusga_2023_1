using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0004 : MonoBehaviour
{
    public CharacterData_So templeteData;
    public float dodgelengthchange;//滑步距离改变值
    public float dodgelengthMin;//滑步距离最小值

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (templeteData.dodgelength > dodgelengthMin+dodgelengthchange)
                templeteData.dodgelength -= dodgelengthchange;
            else
                templeteData.dodgelength = dodgelengthMin;
            Debug.Log(templeteData.dodgelength);

        }
    }
}
