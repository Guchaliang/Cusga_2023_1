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

    public int MaxHealth
    {
        get
        {
            if (characterData != null) return characterData.maxHealth;
            else return 0;
        }
        set { characterData.maxHealth = value; }
    }

    public int CurrentHealth{
        get
        {
            if (characterData != null) return characterData.currentHealth;
            else return 0;
        }
        set { characterData.currentHealth = value; }
    }

    public int Maxdefence
    {
        get
        {
            if (characterData != null) return characterData.maxDenfence;
            else return 0;
        }
        set { characterData.maxDenfence = value; }
    }

    public int CurrentDefence
    {
        get
        {
            if (characterData != null) return characterData.currentDefence;
            else return 0;
        }
        set { characterData.currentDefence = value; }
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

    public float CriticalMultiplier{
        get
        {
            if (attackData != null) return attackData.criticalMultiplier;
            else return 0;
        }
        set { attackData.criticalMultiplier = value; }
        
    }

    public float CritialPercent
    {
        get
        {
            if (attackData != null) return attackData.critialPercent;
            else return 0;
        }
        set { attackData.critialPercent = value; }
    }

    public float Demage
    {
        get
        {
            if (attackData != null) return attackData.demage;
            else return 0;
        }
        set {attackData.demage = value; }
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

    public float WaitTime
    {
        get
        {
            if (attackData != null) return attackData.waitTime;
            else return 0;
        }
        set { attackData.waitTime = value; }
    }
    #endregion

    #region Read from Combat

    //TODO 攻击判定
    public void TakeDamage(CharacterInfo attacker, CharacterInfo defener)
    {
        
    }

    #endregion 
    
}
