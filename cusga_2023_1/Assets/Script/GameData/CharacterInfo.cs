using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    public float maxHealth;//最大生命值

    public float currentHealth;

    public float defence;
    
    public float attackRange;//攻击距离

    public float findRange;//索敌距离

    public float damage;//伤害值

    public float coolDown;//冷却

    public float skillCollDown;//技能冷却
    
    #region Read from Combat

    public void TakeDamage(CharacterInfo attacker, CharacterInfo defener)
    {
        if (defener.defence > 0)
        {
            defener.defence -= attacker.damage;
            if (defener.defence < 0)
            {
                defener.currentHealth += defener.defence;
                defener.defence = 0;
            }
        }

        if (defener.defence == 0)
        {
            defener.currentHealth = Mathf.Max(defener.currentHealth-attacker.damage,0) ;
        }
    }
    
    public void TakeDamage(float damage, CharacterInfo defener)
    {
        if (defener.defence > 0)
        {
            defener.defence -= damage;
            if (defener.defence < 0)
            {
                defener.currentHealth += defener.defence;
                defener.defence = 0;
            }
        }

        if (defener.defence == 0)
        {
            defener.currentHealth = Mathf.Max(defener.currentHealth - damage,0);
        }
    }

    #endregion
}
