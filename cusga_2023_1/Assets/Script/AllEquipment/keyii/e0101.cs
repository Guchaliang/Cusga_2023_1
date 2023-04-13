using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0101 : MonoBehaviour
{
    public bool isdodge;
    public CharacterData_So CharacterData_So;
    public AttackData_So AttackData_So;
    public BagList myBag;
    public float thisattackDamage;//本次携带这件装备后冲撞敌人的伤害值
    public void f0101()
    {
        if (isdodge)//在冲刺状态
        {
            thisattackDamage = AttackData_So.damage + CharacterData_So.currentDefence;//伤害值加上防御值

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))//碰撞的是敌人
        {

            if (myBag.itemList.Find(z => z.itemName.Contains("0101")))//携带了这件装备
                f0101();
        }
    }
}
