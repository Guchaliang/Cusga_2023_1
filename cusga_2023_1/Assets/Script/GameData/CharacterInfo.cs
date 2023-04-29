using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    public CharacterData_So characterData;

    [HideInInspector] public float maxHealth;//最大生命值
    [HideInInspector] public float currentHealth;//当前生命值
    [HideInInspector] public float defence;//护盾量
    [HideInInspector] public float attackRange;//攻击距离
    [HideInInspector] public float findRange;//索敌距离
    [HideInInspector] public float damage;//伤害值
    [HideInInspector] public float coolDown;//冷却
    [HideInInspector] public float skillCollDown;//技能冷却

    private void Awake()
    {
        InitTheInfo();
    }

    public void InitTheInfo()
    {
        if (this.characterData)
        {
            this.maxHealth = characterData.maxHealth;
            this.currentHealth = characterData.maxHealth;
            this.defence = characterData.defence;
            this.attackRange = characterData.attackRange;
            this.findRange = characterData.findRange;
            this.damage = characterData.damage;
            this.coolDown = characterData.CoolDown;
            this.skillCollDown = characterData.SkillCollDown;
        }
    }

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
            defener.currentHealth = Mathf.Max(defener.currentHealth - attacker.damage, 0);
        }

        if (defener.CompareTag("Player"))
        {
            UIManager.Instance.GetUI<HpItemUI>("HpItemUI").ChangeHpValue((int)-attacker.damage);
            defener.GetComponent<PlayerTest>().PlayerGetHit();

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
            defener.currentHealth = Mathf.Max(defener.currentHealth - damage, 0);
        }
        if (defener.CompareTag("Player"))
        {
            UIManager.Instance.GetUI<HpItemUI>("HpItemUI").ChangeHpValue((int)-damage);
            defener.GetComponent<PlayerTest>().PlayerGetHit();
        }
        Debug.Log(defener.currentHealth);
    }
    #endregion


}
