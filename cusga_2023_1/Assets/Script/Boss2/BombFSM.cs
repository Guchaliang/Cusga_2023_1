using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFSM : EnemyFSM
{
    [Header("��ը��Ч")]
    GameObject bombEffect;
    protected override void AttackPlayer()
    {
        IEnumerator bomb = Bomb(bombEffect,2f);
        StartCoroutine(bomb);
    }

    //���壬���ʱ��
    IEnumerator Bomb(GameObject bullet, float delayTime)
    {
        this.gameObject.SetActive(false);
        GameObject _bullet = PoolManager.Release(bullet, this.transform.position);
        _bullet.GetComponent<Bullet>().SetDirection(Vector2.zero);
        _bullet.GetComponent<Bullet>().SetSpeed(0f);
        yield return new WaitForSeconds(delayTime);
        Destroy(_bullet);
        Destroy(this.gameObject);
    }
}
