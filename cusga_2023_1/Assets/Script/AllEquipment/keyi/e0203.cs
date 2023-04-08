using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0203 : MonoBehaviour
{
    enum room_award { health, defence };
    public int roomaward = 0;//奖励类型
    public CharacterData_So characterData_So;
    public BagList myBag;
    public bool ispickup;
    public float award;//奖励值
    void Update()
    {
        if (myBag.itemList.Find(x => x.itemName.Contains("0203")))
        {//装备了这个装备
            if (ispickup && roomaward == (int)room_award.defence)//拾取的类型是defence
            {
                characterData_So.currentHealth += award;
                Debug.Log("health" + characterData_So.currentHealth);

            }
        }
    }
}
