using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "Character Stats/Data" )]
public class CharacterData_So : ScriptableObject
{
    [Header("Character Info")]
    public float maxHealth;//最大生命值

    public float defence;//护盾值
    
    public float attackRange;//攻击距离

    public float findRange;//索敌距离

    public float damage;//伤害值

    public float CoolDown;//攻击冷却

    public float SkillCollDown;//技能冷却
}
