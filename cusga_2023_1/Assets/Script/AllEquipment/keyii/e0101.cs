using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0101 : MonoBehaviour
{
    public bool isdodge;
    public CharacterData_So CharacterData_So;
    public AttackData_So AttackData_So;
    public BagList myBag;
    public float thisattackDamage;//����Я�����װ�����ײ���˵��˺�ֵ
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))//��ײ���ǵ���
        {

            if (myBag.itemList.Find(z => z.itemName.Contains("0101")))//Я�������װ��
                if (isdodge)//�ڳ��״̬
            {
                thisattackDamage= AttackData_So.damage+ CharacterData_So.currentDefence;//�˺�ֵ���Ϸ���ֵ

            }
        }
    }
}
