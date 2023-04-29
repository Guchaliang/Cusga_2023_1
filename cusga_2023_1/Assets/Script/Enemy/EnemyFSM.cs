using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public bool getHit; 
    [HideInInspector] public GameObject Player;//直接获得，不后期获得了,后期放到OnEnable
    public Transform attackPoint;

    [Header("巡逻")]
    public float patrolRange;
    public float patrolMaxTime;
    public float patrolMinTime;
    public Vector2 awakePos;
    public Vector3 initScale;
    [HideInInspector] public Vector2 targetPos;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyInfo = GetComponent<CharacterInfo>();
        agent = GetComponent<PolyNavAgent>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        states = new Dictionary<StateType, IState>();
        initScale = GetComponent<Transform>().localScale;


        states.Add(StateType.Idle, new EnemyState(this));
        states.Add(StateType.Patrol, new PatrolState(this));
        states.Add(StateType.Chase,new ChaseState(this));
        states.Add(StateType.Attack, new AttackState(this));
        states.Add(StateType.GetHit,new GetHitState(this));
        states.Add(StateType.Death,new DeathState(this));
    }

    private void OnEnable()
    {
        enemyInfo.InitTheInfo();
        TransformState(StateType.Idle);
    }

    private void Start()
    {
        TransformState(StateType.Idle);
        
        Player = FindObjectOfType<PlayerTest>().gameObject;
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

        targetPos.x = awakePos.x + randomX;
        targetPos.y = awakePos.y + randomY;

        while (!agent.map.PointIsValid(targetPos))
        {
            randomX = Random.Range(-patrolRange, patrolRange);
            randomY = Random.Range(-patrolRange, patrolRange);

            targetPos.x = awakePos.x + randomX;
            targetPos.y = awakePos.y + randomY;
        }
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
    
    protected virtual void AttackPlayer()
    {
        Collider2D target = Physics2D.OverlapCircle(attackPoint.position, enemyInfo.attackRange,LayerMask.GetMask("Player"));
        
        if (target&&target.CompareTag("Player"))
        {
            enemyInfo.TakeDamage(enemyInfo,target.gameObject.GetComponent<CharacterInfo>());
            //Debug.Log(target.gameObject.name+"血量为"+target.gameObject.GetComponent<CharacterInfo>().currentHealth);
        }
    }

    protected void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            enemyInfo.TakeDamage(this.gameObject.GetComponent<CharacterInfo>(),other.gameObject.GetComponent<CharacterInfo>());
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    public void GetHit()
    {
        IEnumerator hit = HitColor();
        StartCoroutine(hit);
        BiggerAndReturn(this.gameObject, initScale);
    }

    IEnumerator HitColor()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }

    public void BiggerAndReturn(GameObject gameObject, Vector3 initScale)
    {
        gameObject.transform.DOScale(new Vector3(initScale.x * 1.5f, initScale.y * 1.5f, initScale.z * 1.5f), 0.2f).OnComplete(() =>
        {
            gameObject.transform.DOScale(new Vector3(initScale.x, initScale.y, initScale.z), 0.2f);
        });
    }

}
