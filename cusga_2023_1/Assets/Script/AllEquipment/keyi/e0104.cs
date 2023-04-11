using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0104 : MonoBehaviour
{
    enum room_award { health, defence };
    public int roomaward=1;//奖励类型
    public CharacterData_So characterData_So;
    public BagList myBag;
    public bool ispickup;
    public float award;//奖励值
    public void f0104()
    {
        if (ispickup && roomaward == (int)room_award.health)//拾取的类型是health
        {
            characterData_So.currentDefence += award;
            Debug.Log("defence" + characterData_So.currentDefence);

        }
    }
    void Update()
    {
        if (myBag.itemList.Find(x => x.itemName.Contains("0104")))
        {//装备了这个装备
            f0104();
        }
    }
}
