using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0201 : MonoBehaviour
{

    public bool isHit;//�Ƿ�Ϊ�ܻ�״̬
    public AttackData_So AttackData_So;
    public CharacterData_So CharacterData_So;
    public float addDamage;
    public BagList myBag;
    public float testTime;//װ��buffʱ��ʣ��
    public float setTime;//�װ��buffʱ��
    public bool flag = true;
    public bool flag1 = true;
    public float damage1;
    public float currenthealth1;
    public float currentdefence1;

    public void f0201()
    {

        AttackData_So.damage = damage1;
        CharacterData_So.currentDefence = currentdefence1;
        CharacterData_So.currentHealth = currenthealth1;

    }
    void Update()
    {
        if (myBag.itemList.Find(z => z.itemName.Contains("0201")))//Я�������װ��
            if (isHit)//�������Ըĳ����isHit��������ű�����
            {
                if (testTime > 0)
                {
                    testTime -= Time.deltaTime;//һ���Լ�ʱ��
                    if (flag1)
                    {

                        Debug.Log("ԭʼ����" + damage1 + currenthealth1 + currentdefence1);
                        AttackData_So.damage += addDamage;//�ܻ�״̬���˺�

                        CharacterData_So.currentHealth += CharacterData_So.currentHealth;//�������Ϸ���
                        CharacterData_So.currentDefence = 0;//�������
                        flag1 = false;//���˺�ֻ������һ�η���һֱ��
                    }
                }

                else if (testTime <= 0 && flag)
                {
                    testTime = setTime;
                    flag = false;
                    damage1 = AttackData_So.damage;//��¼ԭʼdamage
                    currentdefence1 = CharacterData_So.currentDefence;//ԭʼ����
                    currenthealth1 = CharacterData_So.currentHealth;//ԭʼ����

                }
                if (testTime <= 0 && !flag && !flag1)
                {
                    f0201();//�ָ�������
                }

            }
    }
}

