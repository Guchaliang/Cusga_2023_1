using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0009 : MonoBehaviour
{
    public AttackData_So attackData;
    public float attackRangeMax;//������
    public float attackRangeChange;
   public  void f0009()
    {
        if (attackData.attackRange <= attackRangeMax - attackRangeChange)//����֮ǰС�����Ӻ������ٶ�
            attackData.attackRange += attackRangeChange;
        else
            attackData.attackRange = attackRangeMax;
        Debug.Log(attackData.attackSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            f0009();

        }
    }
}
