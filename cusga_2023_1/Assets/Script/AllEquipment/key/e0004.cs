using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0004 : MonoBehaviour
{
    public CharacterData_So templeteData;
    public float dodgelengthchange;//��������ı�ֵ
    public float dodgelengthMin;//����������Сֵ

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
