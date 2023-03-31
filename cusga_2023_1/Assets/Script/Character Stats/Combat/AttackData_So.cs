using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "Attack Stats/Data" )]
public class AttackData_So : ScriptableObject
{
    public float attackBullet;//攻击子弹种类

    public float attackSpeed;//射速

    public float attackRange;//攻击距离，射程

    public float findRange;//索敌距离

    public float damage;//伤害值

    public float CoolDown;//冷却
    
}
