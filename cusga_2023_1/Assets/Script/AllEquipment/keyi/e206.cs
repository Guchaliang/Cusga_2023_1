using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e206 : MonoBehaviour
{
    public bool isHit;//�Ƿ�Ϊ�ܻ�״̬
    public AttackData_So AttackData_So;
    public CharacterData_So CharacterData_So;
    public BagList myBag;
    public float damage1;//���ι����˺�
    public float suckblood;//��Ѫ��
    public CharacterData_So enemy;
    public int enemycount;//��������
    public float n;//�����е�����ɵĵ����˺�
    public float e206_Id;//206װ����ȴ
    public float thisId;//��ǰװ����ȴʣ��ʱ��
    private bool flag=true;
    // Update is called once per frame
    void Update()
    {
        if (myBag.itemList.Find(z => z.itemName.Contains("0206")))//Я�������װ��
            if (flag)
            { 
                flag = false;
                thisId = e206_Id;
            }     
        if (thisId <0) { //װ����ȴ
            
                if (isHit)//�������Ըĳ����isHit��������ű�����
            {
                if (damage1 > CharacterData_So.currentHealth)//��ǰ�յ����˺�����������ֵ
                {
                    
                    if(Random.Range(0, 10000) / 5 == 0)//20%�ĸ���
                    {
                        damage1 = 0;//����
                        enemy.currentHealth-=n;//ȫ���˺�
                        suckblood += enemycount * 2;//����������2����Ѫ
                        if (CharacterData_So.currentHealth < CharacterData_So.maxHealth)
                            CharacterData_So.currentHealth += suckblood;//��Ѫ
                        else { CharacterData_So.currentHealth = CharacterData_So.maxHealth; }
                    }
                }
            }
        }else if (thisId >=0 )
        { thisId-=Time.deltaTime;  
        }
    }
}
