
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  class BossIdle_2State : IState
{
    float timer;
    private BossFSM m_Boss;

    public BossIdle_2State(BossFSM enemy)
    {
        m_Boss = enemy;
    }
    public void OnEnter()
    {
        m_Boss.animator.Play("Idle_1");
        Debug.Log("Boss状态"+this);
    }
    public void OnUpdate()
    {
    }

    public void OnExit()
    {
        timer = 0;
    }
}

public class BossFrizzy_2State : IState//攻击过程中不可打断
{
    private float timer = 0f;

    private BossFSM m_Boss;
    public BossFrizzy_2State(BossFSM enemy)
    {
        m_Boss = enemy;
    }


    public void OnEnter()
    {
        Debug.Log("Boss状态" + this);
    }

    public void OnUpdate()
    {
    }

    public void OnExit()
    {

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




