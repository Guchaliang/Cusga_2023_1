using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0202 : MonoBehaviour
{
    public bool isHit;//�Ƿ�Ϊ�ܻ�״̬
    public AttackData_So AttackData_So;
    public CharacterData_So CharacterData_So;
    public BagList myBag;
    public float injuryMax;//���������
    public float currentInjury;//��ǰ������
    public float passroom_num;//ͨ����������
    public float thisinjury;//��ǰ�յ����˺�
    public float injury_total;//����Ӧ�ܵ����˺�
    public int room_num_total;//�ܷ����������������÷���Ľű���
    void Update()
    {
        if (myBag.itemList.Find(z => z.itemName.Contains("0202")))//Я�������װ��
            if (isHit)//�������Ըĳ����isHit��������ű�����
            {
                
                if (currentInjury < injuryMax)
                {
                    currentInjury += thisinjury;//��¼��������
                }
                else
                {

                 injury_total = (room_num_total-passroom_num) / room_num_total* injuryMax+(currentInjury-injuryMax);//���ϳ����Ĳ��ֲ���

                }
              
            }
    }
}
