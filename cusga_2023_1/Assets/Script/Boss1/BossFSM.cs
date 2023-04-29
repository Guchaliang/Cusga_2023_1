using System;
using System.Collections;
using System.Collections.Generic;
using PolyNav;
using UnityEngine;
using UnityEngine.Windows;
using DG.Tweening;
using Random = UnityEngine.Random;

public class BossFSM : MonoBehaviour
{
    public Dictionary<BossStateType, IState> states;
    internal IState currentState;

    [HideInInspector] public Animator animator;
    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public CharacterInfo enemyInfo;
    [HideInInspector] public bool getHit;

    [Header("开始攻击时间")]
    public float StartAttackTime = 2f;


    //直接获得，不后期获得了,后期放到OnEnable
    public GameObject Player;

    //public Obstacles obstacles;//TODO 只是测试，后面改

    [HideInInspector] public Vector2 awakePos;
    [HideInInspector] public Vector2 targetPos;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyInfo = GetComponent<CharacterInfo>();
        spriteRenderer = GetComponent<SpriteRenderer>(); 

    }
    private void Start()
    {
        states = new Dictionary<BossStateType, IState>();
        Player = FindObjectOfType<PlayerTest>().gameObject;
        awakePos = transform.position;
    }
    private void FixedUpdate()
    {
        currentState.OnUpdate();
    }
    public void TransformState(BossStateType type)
    {
        if (currentState != null)
            currentState.OnExit();
        currentState = states[type];
        currentState.OnEnter();
    }

    public void AddState(BossStateType state)
    {
        states.Add(state, new BossDeathState(this));
    }

    public void FlipTo()//转向函数
    {
        if (this.transform.position.x < targetPos.x)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    public void BossGetHurt()
    {
        UIManager.Instance.GetUI<BossHpItemUI>("BossHpItemUI").ChangeHpValue(-10);
    }

}
