using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0002 : MonoBehaviour
{
    public AttackData_So attackData;
    public float attackSpeedMax;//最大射速留着给策划调参数的
    public float attackSpeedChange;
    public void f0002()
    {
        if (attackData.attackSpeed <= attackSpeedMax - attackSpeedChange)//射速之前小于增加后的最大速度
            attackData.attackSpeed += attackSpeedChange;
        else
            attackData.attackSpeed = attackSpeedMax;
        Debug.Log(attackData.attackSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            f0002();
        }
    }
}
