using System;
using System.Collections;
using System.Collections.Generic;
using PolyNav;
using UnityEngine;
using UnityEngine.Windows;
using DG.Tweening;
using Random = UnityEngine.Random;
public class BossFSM_2 : BossFSM
{
    [Header("普通子弹")]
    public GameObject basicBullet;

    [Header("自爆怪")]
    public GameObject bombMob;

    [Header("毒气子弹")]
    public GameObject poisonBullet;

    [Header("伤害子弹")]
    public GameObject damageBullet; 

    [Header("环形子弹")]
    public GameObject circleBullet; 

    public int hurtTime = 0;
    public int changeHurtTime = 5;

    private void Start()
    {
        states = new Dictionary<BossStateType, IState>();

        states.Add(BossStateType.Frizzy_2, new BossFrizzy_2State(this));


        TransformState(BossStateType.Idle_2_1);

        Player = FindObjectOfType<PlayerTest>().gameObject;
        awakePos = transform.position;

    }

    //爬向玩家，生成自爆怪，距离玩家一定近距离后嘶吼范围，减速玩家并造成伤害
    public void State1Skill_1()
    {
        //嘶吼范围
        float roarLength = 3f;
        //减速时间
        float slowTime = 5f;
        //减速数值
        float slowValue = 5f;

        Vector2 playerPos = new Vector2(Player.transform.position.x, Player.transform.position.y);
        Vector2 myPos = new Vector2(this.transform.position.x, this.transform.position.y);
        Vector2 dir = (Player.transform.position - this.transform.position);

        this.transform.DOMove(new Vector3(dir.x, dir.y, 0), 2f).SetEase(Ease.OutCubic).OnComplete(() => {
                GameObject stone = PoolManager.Release(bombMob, transform.position, Quaternion.identity);
            if((playerPos-myPos).magnitude< roarLength)
            {
                IEnumerator s = SlowPlayerSpeed(slowTime, slowValue);
                StartCoroutine(s);
                //嘶吼动画
            }
        });
    }

    IEnumerator SlowPlayerSpeed(float slowTime,float slowValue)
    {
        float InitSpeed = Player.GetComponent<PlayerTest2>().movespeed;
        Player.GetComponent<PlayerTest2>().movespeed -= slowValue;
        yield return new WaitForSeconds(slowTime);
        Player.GetComponent<PlayerTest2>().movespeed -= slowValue;
    }

    //方向，速度，子弹物体，间隔时间
    IEnumerator ShootBullet(Vector2 dir,float speed,GameObject bullet,float delayTime)
    {
        GameObject _bullet = PoolManager.Release(bullet, this.transform.position);
        _bullet.GetComponent<Bullet>().SetDirection(dir);
        _bullet.GetComponent<Bullet>().SetSpeed(speed);
        yield return new WaitForSeconds(delayTime);
    }

    //交替发射毒气弹与伤害弹，毒气弹喷到任何地形爆炸产生毒气，玩家经过毒气减速，伤害弹打到玩家会对玩家造成伤害
    public void State1Skill_2()
    {
        //子弹数量
        int count = 5;
        //子弹速度
        float speed = 1f;
        Vector2 direction = (Player.transform.position - this.transform.position).normalized;
        Vector2 playerPos = new Vector2(Player.transform.position.x, Player.transform.position.y);

        for (int i = 0; i < count; i++)
        {
            direction = (Player.transform.position - this.transform.position).normalized;
            if (i % 2 == 1)
            {
                IEnumerator shoot = ShootBullet(direction, speed,damageBullet,1f);
                StartCoroutine(shoot);
            }
            else
            {
                IEnumerator shoot = ShootBullet(direction, speed, poisonBullet, 1f);
                StartCoroutine(shoot);
            }
        }
    }
    //发射圆形扩散的弹幕
    public void State1Skill_3()
    {
        //子弹速度
        float speed = 1f;
        Vector2 direction = (Player.transform.position - this.transform.position).normalized;
        Vector2 playerPos = new Vector2(Player.transform.position.x, Player.transform.position.y);

        IEnumerator shoot = ShootBullet(direction, speed, circleBullet, 1f);
        StartCoroutine(shoot);
    }    


    //干扰玩家心智，玩家的移动方式变成反向映射
    public void State1Skill_4()
    {
        IEnumerator re = ReverseDir(1f);
        StartCoroutine(re);
    }

    //持续时间
    IEnumerator ReverseDir(float delayTime)
    {     
        float speedInit= Player.GetComponent<PlayerTest>().moveSpeed;
        Player.GetComponent<PlayerTest>().SetSpeed(-speedInit);
        yield return new WaitForSeconds(delayTime);
        Player.GetComponent<PlayerTest>().SetSpeed(speedInit);
    }

    //隔很短时间后快速滚向玩家没碰到地形后，重新锁定到玩家
    public void State2Skill_1()
    {

    }
    //向上跳起后落下造成冲击波，被冲击波打到会受到伤害。并且落下后会反弹两次且都会造成冲击波
    public void State2Skill_2()
    {

    }
    //原地高速旋转，在旋转过程中会减速角色并且产生漩涡型子弹，被打到后受到伤害
    public void State2Skill_3()
    {

    }

}


