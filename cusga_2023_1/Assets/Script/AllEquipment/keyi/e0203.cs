using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0203 : MonoBehaviour
{
    enum room_award { health, defence };
    public int roomaward = 0;//��������
    public CharacterData_So characterData_So;
    public BagList myBag;
    public bool ispickup;
    public float award;//����ֵ
    public void f0203()
    {
        if (ispickup && roomaward == (int)room_award.defence)//ʰȡ��������defence
        {
            characterData_So.currentHealth += award;
            Debug.Log("health" + characterData_So.currentHealth);

        }
    }
    void Update()
    {
        if (myBag.itemList.Find(x => x.itemName.Contains("0203")))
        {//װ�������װ��
            f0203();
        }
    }
}
