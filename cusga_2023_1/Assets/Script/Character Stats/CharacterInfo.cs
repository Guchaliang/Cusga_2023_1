using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    public CharacterData_So templeteData;

    [HideInInspector]public CharacterData_So characterData;

    public AttackData_So attackData;
    private void Awake()
    {
        if (templeteData != null)
            characterData = Instantiate(templeteData);
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

    //TODO 攻击判定
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
