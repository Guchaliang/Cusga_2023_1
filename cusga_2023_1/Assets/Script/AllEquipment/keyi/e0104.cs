using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0104 : MonoBehaviour
{
    enum room_award { health, defence };
    public int roomaward=1;//��������
    public CharacterData_So characterData_So;
    public BagList myBag;
    public bool ispickup;
    public float award;//����ֵ
    void Update()
    {
        if (myBag.itemList.Find(x => x.itemName.Contains("0104")))
        {//װ�������װ��
            if (ispickup&&roomaward==(int)room_award.health)//ʰȡ��������health
            {
                characterData_So.currentDefence += award;
                Debug.Log("defence" + characterData_So.currentDefence);

            }
        }
    }
}
