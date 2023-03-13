using System;
using System.Collections;
using System.Collections.Generic;
using PolyNav;
using UnityEngine;
using UnityEngine.Windows;
using Random = UnityEngine.Random;

//小怪  状态 Idle,Patrol,Chase,Attack,GetHit,Death
public class EnemyFSM : MonoBehaviour
{
    private Dictionary<StateType, IState> states;
    private IState currentState;

    [HideInInspector] public Animator animator;
    [HideInInspector] public CharacterInfo enemyInfo;
    [HideInInspector] public PolyNavAgent agent;
    [HideInInspector] public bool getHit;

    public GameObject Player;//直接获得，不后期获得了,后期放到OnEnable

    [Header("子弹")]
    public GameObject bullet;
    public Transform basicBullet;
    
    [Header("巡逻")]
    public float patrolRange;
    public float patrolMaxTime;
    public float patrolMinTime;
    [HideInInspector] public Vector2 awakePos;
    [HideInInspector] public Vector2 targetPos;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyInfo = GetComponent<CharacterInfo>();
        agent = GetComponent<PolyNavAgent>();
    }

    private void Start()
    {
        states = new Dictionary<StateType, IState>();
        
        states.Add(StateType.Idle, new EnemyState(this));
        states.Add(StateType.Patrol, new PatrolState(this));
        states.Add(StateType.Chase,new ChaseState(this));
        states.Add(StateType.Attack, new AttackState(this));
        states.Add(StateType.GetHit,new GetHitState(this));
        states.Add(StateType.Death,new DeathState(this));
        
        TransformState(StateType.Idle);
        
        Player = FindObjectOfType<PlayerTest>().gameObject;

        awakePos = transform.position;
        agent.map = PolyNavMap.current;
    }

    private void FixedUpdate()
    {
        currentState.OnUpdate();
        
    }

    public float GetPatrolTime()
    {
        return Random.Range(patrolMinTime, patrolMaxTime);
    }
    

    public void TransformState(StateType type)
    {
        if (currentState != null)
            currentState.OnExit();
        currentState = states[type];
        currentState.OnEnter();
    }

    //TODO 待后期修改位置参数，防止出现卡住
    public void ChoosePatrolTarget()
    {
        float randomX = Random.Range(-patrolRange,patrolRange);
        float randomY = Random.Range(-patrolRange, patrolRange);
        
        targetPos = new Vector2(awakePos.x+randomX,awakePos.y + randomY);
        
        FlipTo();
    }

    public void FlipTo()//转向函数
    {
        if (this.transform.position.x < targetPos.x)
        {
            this.transform.localScale = new Vector3(1,1,1);
        }
        else
        {
            this.transform.localScale = new Vector3(-1,1,1);
        }
    }
    
    public void AttackPlayer()
    {
        Vector2 direction = (Player.transform.position - this.transform.position).normalized;

        GameObject newBullet = PoolManager.Release(bullet, basicBullet.position, Quaternion.identity);

        newBullet.GetComponent<EnemyBullet>().SetSpeed(direction);
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(awakePos,new Vector2(4,4));
    }
}
