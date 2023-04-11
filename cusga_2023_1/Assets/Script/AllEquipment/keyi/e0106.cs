using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0106 : MonoBehaviour
{
    public AttackData_So AttackData_So;
    public CharacterData_So CharacterData_So;
    public BagList myBag;
    public float delDamage;
    public float delDodgeId;
    public void f0106()
    {
        AttackData_So.damage -= delDamage;//攻击力下降
        CharacterData_So.dodgeId -= delDodgeId;//冲刺Id减少
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //装备了这个装备
            
            f0106();
                
                }
    }
}