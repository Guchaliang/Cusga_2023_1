using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0009 : MonoBehaviour
{
    public AttackData_So attackData;
    public float attackRangeMax;//最大射程
    public float attackRangeChange;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (attackData.attackRange <= attackRangeMax - attackRangeChange)//射速之前小于增加后的最大速度
                attackData.attackRange += attackRangeChange;
            else
                attackData.attackRange = attackRangeMax;
            Debug.Log(attackData.attackSpeed);

        }
    }
}
