using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0004 : MonoBehaviour
{
    public CharacterData_So templeteData;
    public float dodgelengthchange;//��������ı�ֵ
    public float dodgelengthMin;//����������Сֵ
    public void f0004()
    {
        if (templeteData.dodgelength -dodgelengthchange> dodgelengthMin )
            templeteData.dodgelength -= dodgelengthchange;
        else
            templeteData.dodgelength = dodgelengthMin;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            f0004();

        }
    }
}
