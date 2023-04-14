using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyEquipment : MonoBehaviour
{
    public BagList bag;
    public CharacterData_So original;
    public CharacterData_So current;
    public AttackData_So currentAttack;
    public AttackData_So originalAttack;
    public bool equ_Throw;
    public GameObject e0001,e0002,e0003,e0004,e0005,e0006,e0007,e0008,e0009,e0010,e0011,e0012;
    public GameObject e0101, e0201;
    public GameObject e0102,e0103,e0104,e0105,e0106,e0202,e0203,e0204,e0205,e0206;
     public void init_current()
    {
        current.damage = original.damage;
        current.maxHealth = original.maxHealth;
        current.currentDefence = original.currentDefence;
        current.currentHealth = original.currentHealth;
        current.Defence = original.Defence;
        current.dashSpeed = original.dashSpeed;
        current.dashLength = original.dashLength;
        current.addSpeed = original.addSpeed;
        current.delSpeed = original.delSpeed;
        current.dodgeId = original.dodgeId;
        current.dodgelength = original.dodgelength;
        current.defencedropRate = original.defencedropRate;
        current.healthdropRate = original.healthdropRate;
        current.room_award = original.room_award;
        current.boss_award = original.boss_award;
        current.protect = original.protect;
        current.defence = original.defence;
        current.attackRange = original.attackRange;
        current.CoolDown = original.CoolDown;
        current.SkillCollDown = original.SkillCollDown;
        currentAttack.attackBullet = originalAttack.attackBullet;
        currentAttack.damage = originalAttack.damage;   
        currentAttack.attackRange = originalAttack.attackRange;
        currentAttack.CoolDown = originalAttack.CoolDown;
        currentAttack.attackSpeed = originalAttack.attackSpeed;
        currentAttack.findRange = originalAttack.findRange;
    }

    //ÿ��װ�����˾����¼���
    public void bagList_sub(string Itemname)
    {
        Debug.Log("����ж��");
        init_current();//��ʼ����¼original������
        if(bag.itemList.Exists(item => item.itemName.Contains(Itemname)))
        bag.itemList.Remove(bag.itemList.Find(item => item.itemName.Contains(Itemname)));//�ӱ������Ƴ�װ��
        switch (Itemname)//�綪����װ����swith�е�
        {
            case "0010": { e0010.transform.GetComponent<e0010>().isavoidHit = false; break; }
            case "0011": { current.dodgeId=e0011.transform.GetComponent<e0011>().Dolgeid; break; }//�ظ�ԭ������id
            case "0201": { e0201.transform.GetComponent<e0201>().f0201(); break; }//�ظ�ԭ�е�����
            case "0102": { e0102.transform.GetComponent<e0102>().isdelDefence=false; break; }//���۷���ֵʧЧ
            case "0103": { e0103.transform.GetComponent<e0103>().isf0103=false; break; }//f0103�ű�ʧЧ
            case "0105": { e0105.transform.GetComponent<e0105>().f0105(); break; }//�ظ�ԭ�е�����
            case "0202": { e0202.transform.GetComponent<e0202>().ise0202 = false; break; }//e0202�ű�ʧЧ
            case "0204": { e0204.transform.GetComponent<e0204>().isf0204 = false; break; }//f0204�ű�ʧЧ
            case "0206": { e0206.transform.GetComponent<e0206>().isf0206 = false; break; }//f0204�ű�ʧЧ
            default:
                {
                    for (int i = 0; i < bag.itemList.Count; i++)
                    {
                        switch (bag.itemList[i].name)
                        {
                            case "0001": { e0001.transform.GetComponent<e0001>().f0001(); break; }
                            case "0002": { e0002.transform.GetComponent<e0002>().f0002(); break; }
                            case "0003": { e0003.transform.GetComponent<e0003>().f0003(); break; }
                            case "0004": { e0004.transform.GetComponent<e0004>().f0004(); break; }
                            case "0005": { e0005.transform.GetComponent<e0005>().f0005(); break; }
                            case "0006": { e0006.transform.GetComponent<e0006>().f0006(); break; }
                            case "0007": { e0007.transform.GetComponent<e0007>().f0007(); break; }
                            case "0008": { e0008.transform.GetComponent<e0008>().f0008(); break; }
                            case "0009": { e0009.transform.GetComponent<e0009>().f0009(); break; }
                            case "0012": { e0012.transform.GetComponent<e0012>().f0012(); break; }
                            case "0101": { e0101.transform.GetComponent<e0101>().f0101(); break; }
                            case "0104": { e0104.transform.GetComponent<e0104>().f0104(); break; }
                            case "0106": { e0106.transform.GetComponent<e0106>().f0106(); break; }
                            case "0203": { e0203.transform.GetComponent<e0203>().f0203(); break; }


                        }
                    }
                    break;
                }
        }
        
        
    }

}
