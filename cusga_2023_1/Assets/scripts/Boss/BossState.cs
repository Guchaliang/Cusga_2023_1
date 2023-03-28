
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Boss 状态 Idle,Chase,Attack,Death
public class BossState : IState//Idle状态
{
    float timer;
    private BossFSM m_Boss;
    public BossState(BossFSM enemy)
    {
        m_Boss = enemy;
    }


    public void OnEnter()
    {
        m_Boss.animator.Play("Idle");
        Debug.Log("Boss状态"+this);
    }

    public void OnUpdate()
    {
        //TODO 进入房间后，可以行动
        timer += Time.deltaTime;

        if (m_Boss.getHit)
            m_Boss.TransformState(StateType.GetHit);
        if (timer >= m_Boss.StartAttackTime)
            m_Boss.TransformState(StateType.Attack1);
    }

    public void OnExit()
    {
        timer = 0;
    }
}



public class BossAttack1State : IState//攻击过程中不可打断
{
    private float timer = 0f;

    private BossFSM m_Boss;
    public BossAttack1State(BossFSM enemy)
    {
        m_Boss = enemy;
    }


    public void OnEnter()
    {
        m_Boss.Invoke("State1Skill_1", 0);
        Debug.Log("Boss状态" + this);
    }

    public void OnUpdate()
    {
        timer += Time.deltaTime;

        if (m_Boss.getHit)
            m_Boss.TransformState(StateType.GetHit);
        if (timer >= m_Boss.StartAttackTime)
            m_Boss.TransformState(StateType.Attack2);
    }

    public void OnExit()
    {

    }
}
public class BossAttack2State : IState//攻击过程中不可打断
{
    float timer = 0f;
    private BossFSM m_Boss;
    public BossAttack2State(BossFSM enemy)
    {
        m_Boss = enemy;
    }


    public void OnEnter()
    {
        m_Boss.Invoke("State1Skill_2", 0);
        Debug.Log("Boss状态" + this);
    }

    public void OnUpdate()
    {
        timer += Time.deltaTime;

        if (m_Boss.getHit)
            m_Boss.TransformState(StateType.GetHit);
        if (timer >= m_Boss.StartAttackTime)
            m_Boss.TransformState(StateType.Attack3);

    }

    public void OnExit()
    {

    }
}

public class BossAttack3State : IState//攻击过程中不可打断
{
    float timer = 0f;
    private BossFSM m_Boss;
    public BossAttack3State(BossFSM enemy)
    {
        m_Boss = enemy;
    }


    public void OnEnter()
    {
        //m_Boss.Invoke("State2Skill_1", 0);
        Debug.Log("Boss状态" + this);
    }

    public void OnUpdate()
    {
        timer += Time.deltaTime;

        if (m_Boss.getHit)
            m_Boss.TransformState(StateType.GetHit);
        if (timer >= m_Boss.StartAttackTime)
            m_Boss.TransformState(StateType.Attack4);

    }

    public void OnExit()
    {

    }
}

public class BossAttack4State : IState//攻击过程中不可打断
{
    float timer = 0f;
    private BossFSM m_Boss;
    public BossAttack4State(BossFSM enemy)
    {
        m_Boss = enemy;
    }


    public void OnEnter()
    {
        m_Boss.Invoke("State2Skill_2", 0);
        Debug.Log("Boss状态" + this);
    }

    public void OnUpdate()
    {
        timer += Time.deltaTime;
        if (m_Boss.getHit)
            m_Boss.TransformState(StateType.GetHit);
        if (timer >= m_Boss.StartAttackTime)
            m_Boss.TransformState(StateType.Attack5);
    }

    public void OnExit()
    {

    }
}

public class BossAttack5State : IState//攻击过程中不可打断
{
    float timer = 0f;
    private BossFSM m_Boss;
    public BossAttack5State(BossFSM enemy)
    {
        m_Boss = enemy;
    }


    public void OnEnter()
    {
        //m_Boss.Invoke("State2Skill_3", 0);
        Debug.Log("Boss状态" + this);
    }

    public void OnUpdate()
    {
        timer += Time.deltaTime;
        if (m_Boss.getHit)
            m_Boss.TransformState(StateType.GetHit);
        if (timer >= m_Boss.StartAttackTime)
            m_Boss.TransformState(StateType.Attack6);

    }

    public void OnExit()
    {

    }
}
public class BossAttack6State : IState//攻击过程中不可打断
{
    float timer = 0f;
    private BossFSM m_Boss;
    public BossAttack6State(BossFSM enemy)
    {
        m_Boss = enemy;
    }


    public void OnEnter()
    {
        //m_Boss.Invoke("State3Skill_1", 0);
        Debug.Log("Boss状态" + this);
    }

    public void OnUpdate()
    {
        timer += Time.deltaTime;
        if (m_Boss.getHit)
            m_Boss.TransformState(StateType.GetHit);
        if (timer >= m_Boss.StartAttackTime)
            m_Boss.TransformState(StateType.Attack7);

    }

    public void OnExit()
    {

    }
}

public class BossAttack7State : IState//攻击过程中不可打断
{
    float timer = 0f;
    private BossFSM m_Boss;
    public BossAttack7State(BossFSM enemy)
    {
        m_Boss = enemy;
    }


    public void OnEnter()
    {
        m_Boss.Invoke("State3Skill_2", 0);
        Debug.Log("Boss状态" + this);
    }

    public void OnUpdate()
    {
        timer += Time.deltaTime;
        if (m_Boss.getHit)
            m_Boss.TransformState(StateType.GetHit);
        if (timer >= m_Boss.StartAttackTime)
            m_Boss.TransformState(StateType.Attack8);
    }

    public void OnExit()
    {

    }
}
public class BossAttack8State : IState//攻击过程中不可打断
{
    float timer = 0f;
    private BossFSM m_Boss;
    public BossAttack8State(BossFSM enemy)
    {
        m_Boss = enemy;
    }


    public void OnEnter()
    {
        m_Boss.Invoke("State3Skill_3", 0);
        Debug.Log("Boss状态" + this);
    }

    public void OnUpdate()
    {
        timer += Time.deltaTime;
        if (m_Boss.getHit)
            m_Boss.TransformState(StateType.GetHit);
        if (timer >= m_Boss.StartAttackTime)
            m_Boss.TransformState(StateType.Idle);
    }

    public void OnExit()
    {

    }
}
public class BossGetHitState : IState
{ 
    private BossFSM m_Boss;

    public BossGetHitState(BossFSM enemy)
    {
        m_Boss = enemy;
    }


    public void OnEnter()
    {
        m_Boss.animator.Play("GetHit");
    }

    public void OnUpdate()
    {
        //受击函数
    }

    public void OnExit()
    {
        m_Boss.getHit = false;
    }
}

public class BossDeathState : IState
{
    private BossFSM m_Boss;

    public BossDeathState(BossFSM enemy)
    {
        m_Boss = enemy;
    }

    public void OnEnter()
    {
        m_Boss.animator.Play("Death");
        Debug.Log(this);
    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {
    }
}




