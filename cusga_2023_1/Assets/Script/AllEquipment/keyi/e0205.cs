using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0205 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isHit;//�Ƿ�Ϊ�ܻ�״̬
    public AttackData_So AttackData_So;
    public CharacterData_So CharacterData_So;
    public BagList myBag;
    public float testTime;//װ��buffʱ��ʣ��
    public float setTime;//�װ��buffʱ��
    public bool flag = true;
    public float damage1;//���ι����˺�
    public float suckblood;//��Ѫ��
    public float suckbloodRate;//��Ѫ��
    public float delmaxHealth;//���ÿ۳�n��Ѫ������
    // Update is called once per frame
    void Update()
    {
        if (myBag.itemList.Find(z => z.itemName.Contains("0205")))//Я�������װ��
            if (isHit)//�������Ըĳ����isHit��������ű�����
            {
                if (testTime > 0)
                {
                    testTime -= Time.deltaTime;//һ���Լ�ʱ��
                    suckblood = suckbloodRate * damage1;//��Ѫ��
                    if (CharacterData_So.currentHealth < CharacterData_So.maxHealth)
                        CharacterData_So.currentHealth += suckblood;
                    else { CharacterData_So.currentHealth = CharacterData_So.maxHealth; }
                }


                else if (testTime <= 0 && flag)//��ʱ����
                {
                   
                    CharacterData_So.maxHealth -= delmaxHealth;
                    CharacterData_So.currentHealth -= CharacterData_So.maxHealth;
                    flag = false;
                     testTime = setTime;
                }
            }
    }
    }

