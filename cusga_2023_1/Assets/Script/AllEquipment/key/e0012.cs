using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0012 : MonoBehaviour
{
    public CharacterData_So templeteData;//�󶨹���
    // Update is called once per frame
    public void f0012()
    {
        if (templeteData.currentHealth <= 0)//��ɱ�����õ��ǵ���Ѫ������0�������ٵ�
        {
            templeteData.boss_award += 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            f0012();
        }
    }
}

