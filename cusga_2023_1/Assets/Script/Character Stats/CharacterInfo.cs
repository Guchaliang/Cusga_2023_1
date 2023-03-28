using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    public CharacterData_So templeteData;
    [HideInInspector]public CharacterData_So characterData;

    public AttackData_So temattackData;
    [HideInInspector] public AttackData_So attackData;

    private void Awake()
    {
        templeteData.maxHealth = 100;
        templeteData.currentHealth = 100;
        templeteData.Defence = 100;
        templeteData.currentDefence = 100;
        templeteData.dashSpeed = 100;
        templeteData.dashSpeed = 2;
        templeteData.dashLength = 2;
        templeteData.maxSpeed = 4;
        templeteData.addSpeed = 4;
        templeteData.delSpeed = 4;
        templeteData.dodgeId = 3;
        templeteData.dodgelength = 2;
        temattackData.attackBullet=1;//攻击子弹种类,从一到4中随机

        temattackData.attackSpeed=2.0f;//射速

        temattackData.attackRange=6;//攻击距离，射程

        temattackData.findRange=6;//索敌距离

        temattackData.damage=5;//伤害值

        temattackData.CoolDown=3;//冷却
        if (templeteData != null)
            characterData = Instantiate(templeteData);
        if (attackData != null)
            attackData = Instantiate(temattackData);
    }

    #region Read from Info

    public float MaxHealth
    {
        get
        {
            if (characterData != null) return characterData.maxHealth;
            else return 0;
        }
        set { characterData.maxHealth = value; }
    }

    public float CurrentHealth{
        get
        {
            if (characterData != null) return characterData.currentHealth;
            else return 0;
        }
        set { characterData.currentHealth = value; }
    }

    public float Defence

    {
        get
        {
            if (characterData != null) return characterData.Defence;
            else return 0;
        }
        set { characterData.Defence = value; }
    }
    public float currentDefence
    {
        get
        {
            if (characterData != null) return characterData.currentDefence;
            else return 0;
        }
        set { characterData.currentDefence = value; }
    }
    public float dashSpeed
    {
        get
        {
            if (characterData != null) return characterData.dashSpeed;
            else return 0;
        }
        set { characterData.dashSpeed = value; }
    }
    public float maxSpeed
    {
        get
        {
            if (characterData != null) return characterData.maxSpeed;
            else return 0;
        }
        set { characterData.maxSpeed = value; }
    }
    public float addSpeed
    {
        get
        {
            if (characterData != null) return characterData.addSpeed;
            else return 0;
        }
        set { characterData.addSpeed = value; }
    }
    public float delSpeed
    {
        get
        {
            if (characterData != null) return characterData.delSpeed;
            else return 0;
        }
        set { characterData.delSpeed = value; }
    }
    public float dodgeId
    {
        get
        {
            if (characterData != null) return characterData.dodgeId;
            else return 0;
        }
        set { characterData.dodgeId = value; }
    }
    public float dodgeLength
    {
        get
        {
            if (characterData != null) return characterData.dodgelength;
            else return 0;
        }
        set { characterData.dodgelength = value; }
    }
    public float attackBullet
    {
        get
        {
            if (attackData != null) return attackData.attackBullet;
            else return 0;
        }
        set { attackData.attackBullet = value; }
    }
    public float AttackSpeed
    {
        get
        {
            if (attackData != null) return attackData.attackSpeed;
            else return 0;
        }
        set { attackData.attackSpeed = value; }
    }
    
    public float AttackRange
    {
        get
        {
            if (attackData != null) return attackData.attackRange;
            else return 0;
        }
        set { attackData.attackRange = value; }
    }

    public float FindRange
    {
        get
        {
            if (attackData != null) return attackData.findRange;
            else return 0;
        }
        set { attackData.findRange = value; }
    }

    public float Damage
    {
        get
        {
            if (attackData != null) return attackData.damage;
            else return 0;
        }
        set {attackData.damage = value; }
    }
    
    public float CoolDown
    {
        get
        {
            if (attackData != null) return attackData.CoolDown;
            else return 0;
        }
        set { attackData.CoolDown = value; }
    }
    #endregion 

    #region Read from Combat

    //TODO 近身攻击判定
    public void TakeDamage(CharacterInfo attacker, CharacterInfo defener)
    {
        if (defener.Defence != 0)
        {
            defener.Defence -= attacker.Damage;
        }
        else
        {
            defener.CurrentHealth -= attacker.Damage;
        }
    }
    
    public void TakeDamage(float damage, CharacterInfo defener)
    {
        if (defener.Defence != 0)
        {
            defener.Defence -= damage;
        }
        else
        {
            defener.CurrentHealth -= damage;
        }
    }

    #endregion 
    
}
