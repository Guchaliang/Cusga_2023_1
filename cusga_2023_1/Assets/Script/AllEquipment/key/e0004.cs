using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0004 : MonoBehaviour
{
    public CharacterData_So templeteData;
    public float dodgelengthchange;//滑步距离改变值
    public float dodgelengthMin;//滑步距离最小值
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
