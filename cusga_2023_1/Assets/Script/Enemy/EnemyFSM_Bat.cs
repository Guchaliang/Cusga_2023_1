using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM_Bat : EnemyFSM
{
    [Header("子弹")]
    public GameObject bullet;

    protected override void AttackPlayer()
    {
        Vector2 direction = (Player.transform.position - this.transform.position).normalized;

        GameObject newBullet = PoolManager.Release(bullet, attackPoint.position, Quaternion.identity);

        newBullet.GetComponent<Bullet>().SetDirection(direction);
        newBullet.GetComponent<Bullet>().SetSpeed(5);    
    }
}
