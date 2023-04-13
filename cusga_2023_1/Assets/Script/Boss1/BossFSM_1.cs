using System;
using System.Collections;
using System.Collections.Generic;
using PolyNav;
using UnityEngine;
using UnityEngine.Windows;
using DG.Tweening;
using Random = UnityEngine.Random;


public class BossFSM_1 : BossFSM,IGetHurt
{
    [Header("子弹")]
    public GameObject bullet;
    public Transform basicBullet;

    [Header("粘液雨子弹")]
    public GameObject rainBullet;

    [Header("粘液子弹")]
    public GameObject mucusBullet; 
    
    [Header("分裂的粘液子弹")]
    public GameObject explodeMucusBullet;

    [Header("粘液池")]
    public GameObject mucusPool;

    [Header("未爆炸的粘液球")]
    public GameObject mucusBall;

    [Header("爆炸的粘液球")]
    public GameObject explodeMucusBall;


    [Header("石头怪")]
    public GameObject stoneMob;

    public CharacterInfo info;

    public int hurtTime = 0;
    public int changeHurtTime = 5;

    private void Start()
    {
        states = new Dictionary<BossStateType, IState>();
        states.Add(BossStateType.Debut1_1, new BossDebut1_1State(this));
        states.Add(BossStateType.Debut1_2, new BossDebut1_2State(this));
        states.Add(BossStateType.Debut1_3, new BossDebut1_3State(this));       
        
        states.Add(BossStateType.Idle_1_1, new BossIdle1_1State(this));
        states.Add(BossStateType.Idle_1_2, new BossIdle1_2State(this));
        states.Add(BossStateType.Idle_1_3, new BossIdle1_3State(this));

        states.Add(BossStateType.Attack_1_1, new BossAttack1_1State(this));
        states.Add(BossStateType.Attack_1_2, new BossAttack1_2State(this));
        states.Add(BossStateType.Attack_1_3, new BossAttack1_3State(this));

        states.Add(BossStateType.GetHit_1_1, new BossGetHit1_1State(this));
        states.Add(BossStateType.GetHit_1_2, new BossGetHit1_2State(this));
        states.Add(BossStateType.GetHit_1_3, new BossGetHit1_3State(this));

        states.Add(BossStateType.Death_1_1, new BossDeath1_1State(this));
        states.Add(BossStateType.Death_1_2, new BossDeath1_2State(this));
        states.Add(BossStateType.Death_1_3, new BossDeath1_3State(this));

        TransformState(BossStateType.Debut1_1);

        Player = FindObjectOfType<PlayerTest>().gameObject;
        awakePos = transform.position;

        info = GetComponent<CharacterInfo>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {

        }
    }

    public void GetHit(float damage)
    {
        IEnumerator hit = HitColor();
        StartCoroutine(hit);
        UIManager.Instance.GetUI<BossHpItemUI>("BossHpItemUI").ChangeHpValue(-damage*10);
        if (hurtTime >= changeHurtTime)
        {
            TransformState(BossStateType.Death_1_1);
            //UIManager.Instance.GetUI<BossHpItemUI>("BossHpItemUI").SetMax(100);
            hurtTime = 0;
        }
    }
        IEnumerator HitColor()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }

    public void ChangeState(BossStateType state,float hpValue)
    {
        TransformState(state);
    }

    public void AttackPlayer()
    {
        int time = 5;
        int place = 5;
        Vector2 direction = (Player.transform.position - this.transform.position).normalized;
        Vector2 playerPos = new Vector2(Player.transform.position.x, Player.transform.position.y);
        Vector2 dir2 = (Player.transform.position - this.transform.position) / time;


        Vector2[] vector2s;
        vector2s = new Vector2[place];

        for (int i = 0; i < place; i++)
        {
            vector2s[i] = playerPos - i * dir2;
            GameObject bossBullet = PoolManager.Release(bullet, vector2s[i], Quaternion.identity);
            bossBullet.GetComponent<Bullet>().SetDirection(Vector2.zero);
        }
    }

    //简单计时器
    IEnumerator Timer(float delayTime, bool boolean)
    {
        float nowTime = 0;
        while (nowTime < delayTime)
        {
            yield return new WaitForSeconds(1.0f);
            nowTime += 1f;
        }
        boolean = false;
        Debug.Log(boolean);
    }

    //粘液雨，持续I0s，在场内随机落下大量粘液球，球落地1s后消失，被砸中后受到伤害
    public void State1Skill_1()
    {
        //每波粘液球降落间隔时间
        float delayTime = 0.5f;
        //波数
        int  rainCount = 4;
        //持续时间
        float lastTime = 10f;
        //总计粘液球数
        int place = 12;
        //粘液球爆炸时间
        float explodeTime=1f;

        bool skillOn = true;

        IEnumerator timer1 = Timer(lastTime, skillOn);
        if (skillOn)
        {
            IEnumerator rain = RainMucus(delayTime, lastTime, place,rainCount,explodeTime);
            StartCoroutine(rain);
        }
    }

    IEnumerator RainMucus(float delayTime,float lastTime = 10f, int rainPlace = 12,int rainCount =4,float explodeTime =1f)
    {
        Vector2[] vector2s;
        vector2s = new Vector2[rainPlace];

        float limitHeight= 3.5f;
        float limitWeight= 5f;


        for (int i = 0; i < rainPlace; i++)
        {
            yield return new WaitForSeconds(delayTime);
 
                float x = Random.Range(-limitWeight, limitWeight);//规定x轴方向上的范围
                float y = Random.Range(-limitHeight, limitHeight);//规定z轴方向上的范围
                vector2s[i] = new Vector2(x, y);

                //在随机地点创建瞄准地区
                GameObject bossBullet = PoolManager.Release(rainBullet, vector2s[i], Quaternion.identity);
                bossBullet.GetComponent<Bullet>().SetDirection(Vector2.zero);
                IEnumerator killBullet = KillBullet(2, bossBullet);
                StartCoroutine(killBullet);

                //开始爆炸倒计时
                IEnumerator r = RainExplode(explodeTime,bossBullet.transform.position);
                StartCoroutine(r);
            
        }
    }

    IEnumerator RainExplode(float explodeTime,Vector2 pos)
    {
        yield return new WaitForSeconds(explodeTime);
        GameObject bossBullet = PoolManager.Release(explodeMucusBall, pos, Quaternion.identity);
        bossBullet.GetComponent<Bullet>().SetDirection(Vector2.zero);
        IEnumerator k = KillBullet(1, bossBullet);
        StartCoroutine(k);
    }


    //从地表不断的喷出粘液，被到后将被减速(减速不叠加)，受到少量伤害
    public void State1Skill_2()
    {
        Vector2 playerPos = new Vector2(Player.transform.position.x, Player.transform.position.y);
        Vector2 dir = (Player.transform.position - this.transform.position);
        IEnumerator shoot = ShootDelayBullet(5, playerPos, dir, 0.5f, 3f,mucusBullet);
        StartCoroutine(shoot);
    }


    IEnumerator KillBullet(float delayTime,GameObject bullet)
    {
        yield return new WaitForSeconds(delayTime);
        bullet.gameObject.SetActive(false);

    }

    /// <summary>
    /// 发射会延迟爆炸的子弹
    /// </summary>
    /// <param name="time">子弹数量</param>
    /// <param name="playerPos"></param>
    /// <param name="dir"></param>
    /// <param name="delayTime">每延迟一段时间 出现一个子弹</param>
    /// <returns></returns>
    IEnumerator ShootDelayBullet(int time, Vector2 playerPos, Vector2 dir, float delayTime,float lastTime, GameObject delayBullet)
    {

        Vector2 myPos = new Vector2(transform.position.x, transform.position.y); ;
        Vector2[] track;
        track = new Vector2[8];
        for (int i = 0; i < time; i++)
        {
            track[i] = myPos + i * dir / time;
            yield return new WaitForSeconds(delayTime);
            GameObject bossBullet = PoolManager.Release(delayBullet, track[i], Quaternion.identity);    
            IEnumerator k = KillBullet(lastTime,bossBullet);
            StartCoroutine(k);
        }
    }

    //向主角方向移动，到一定距离后吐出液体，玩家碰到液体后扣血
    public void State2Skill_1()
    {
        //粘液池持续时间
        float mucusPoolLastTime = 3f;

        Vector2 playerPos = new Vector2(Player.transform.position.x, Player.transform.position.y);
        Vector2 dir = (Player.transform.position - this.transform.position);
        this.transform.DOMove(new Vector3(dir.x, dir.y, 0), 2f).SetEase(Ease.OutCubic).OnComplete(() =>{
            GameObject bossBullet = PoolManager.Release(mucusPool, playerPos-dir, Quaternion.identity);
            IEnumerator killBullet = KillBullet(mucusPoolLastTime, bossBullet);
            StartCoroutine(killBullet);

        }) ;
    }

    //向主角吐出粘液球，粘液球越飞越慢，当粘液球速度为0时销毁，向角色发射5题小散弹
    public void State2Skill_2()
    {

        float startValue = 5;
        float delayTime = 0.5f;
        float deduceValue = 1f;

        Vector2 dir = (Player.transform.position - this.transform.position);
        GameObject bossBullet = PoolManager.Release(mucusBall, transform.position, Quaternion.identity);
        bossBullet.GetComponent<Bullet>().SetDirection(dir/10);  
        IEnumerator slowDownBullet = MucusBallExplode(bossBullet, startValue, delayTime, deduceValue,dir);
        StartCoroutine(slowDownBullet);
    }

    /// <summary>
    /// 粘液球减速爆炸
    /// </summary>
    /// <param name="bullet"></param>
    /// <param name="startValue">开始速度</param>
    /// <param name="delayTime">每次减速所需时间</param>
    /// <param name="deduceValue">每次减速的数值</param>
    /// <returns></returns>
    IEnumerator MucusBallExplode(GameObject bullet,float startValue,float delayTime,float deduceValue,Vector2 dir)
    {
        float value = startValue;
        while (value >= 0)
        {
            value -= 2;
            bullet.GetComponent<Bullet>().SetSpeed(value);
            yield return new WaitForSeconds(delayTime);
        }
        Vector2 explodePos = bullet.transform.position;
        Vector2 playerPos = Player.transform.position;
        Destroy(bullet);
        for (int i = 0; i < 5; i++)
        {
            GameObject bossBullet = PoolManager.Release(explodeMucusBall, explodePos, Quaternion.identity);
            bossBullet.GetComponent<Bullet>().SetSpeed(1f);
            bossBullet.GetComponent<Bullet>().SetDirection(playerPos-explodePos);
            Quaternion q = Quaternion.AngleAxis(-60 + i * 30, Vector3.forward);
            
            Vector2 newDir = q * dir;
            bossBullet.GetComponent<Bullet>().SetDirection(playerPos - explodePos+newDir);
            

        }
        
    }

    //在场内吐出小滚石怪n只
    public void State2Skill_3()
    {
        int stoneMobCount = 5;
        for (int i = 0; i < stoneMobCount; i++)
        {
            GameObject stone= PoolManager.Release(stoneMob, transform.position, Quaternion.identity);
        }
    }

    //隔一段时间向角色连续发射5颗子弹并且子弹速度很快，被打到后受到伤害
    public void State3Skill_1()
    {

        int time = 5;
        Vector2 direction = (Player.transform.position - this.transform.position).normalized;
        Vector2 playerPos = new Vector2(Player.transform.position.x, Player.transform.position.y);
        Vector2 dir2 = (Player.transform.position - this.transform.position);

        for (int i = 0; i < time; i++)
        {       
            GameObject bossBullet = PoolManager.Release(bullet, transform.position, Quaternion.identity);
            bossBullet.GetComponent<Bullet>().SetDirection(dir2);
            bossBullet.GetComponent<Bullet>().SetSpeed(10f);
            IEnumerator killBullet = KillBullet(5f, bossBullet);
            StartCoroutine(killBullet);
        }
    }

    //向玩家高速移动井慢慢减速，冲撞角色，被撞到受到伤害
    public void State3Skill_2()
    {
        Vector2 playerPos = new Vector2(Player.transform.position.x, Player.transform.position.y);
        Vector2 dir = (Player.transform.position - this.transform.position) / 2;
        this.transform.DOMove(new Vector3(dir.x, dir.y, 0), 2f).SetEase(Ease.OutCubic).OnComplete(() => { State1Skill_2(); });
    }


    //沿着上下左右方向向玩家吐腐肉液，命中后玩家受到攻击
    public void State3Skill_3()
    {
        int time = 4;
        Vector2 direction = (Player.transform.position - this.transform.position).normalized;
        Vector2[] directions = { Vector2.up, Vector2.down, Vector2.right, Vector2.left };

        for (int i = 0; i < time; i++)
        {
            GameObject bossBullet = PoolManager.Release(bullet, transform.position, Quaternion.identity);
            bossBullet.GetComponent<Bullet>().SetDirection(directions[i]);
            bossBullet.GetComponent<Bullet>().SetSpeed(5f);
            IEnumerator killBullet = KillBullet(5f, bossBullet);
            StartCoroutine(killBullet);
        }
    }

    public void GetHurt()
    {
        UIManager.Instance.GetUI<BossHpItemUI>("BossHpItemUI").ChangeHpValue(-10);
    }
    
}