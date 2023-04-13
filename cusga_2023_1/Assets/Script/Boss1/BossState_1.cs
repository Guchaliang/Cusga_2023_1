
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossDebut1_1State : IState
{
    private BossFSM m_Boss;

    public BossDebut1_1State(BossFSM enemy)
    {
        m_Boss = enemy;
    }

    public void OnEnter()
    {
        UIManager.Instance.ShowUI<BossHpItemUI>("BossHpItemUI");
        UIManager.Instance.GetUI<BossHpItemUI>("BossHpItemUI").SetName("腐肉球");
        UIManager.Instance.GetUI<BossHpItemUI>("BossHpItemUI").SetMax(50);
        
        m_Boss.animator.Play("Debut_1");
    }

    public void OnUpdate()
    {
    }

    public void OnExit()
    {

    }
}

public class BossDebut1_2State : IState
{
    private BossFSM m_Boss;

    public BossDebut1_2State(BossFSM enemy)
    {
        m_Boss = enemy;
    }

    public void OnEnter()
    {
        UIManager.Instance.GetUI<BossHpItemUI>("BossHpItemUI").SetName("肉球");
        UIManager.Instance.GetUI<BossHpItemUI>("BossHpItemUI").SetMax(100);
        m_Boss.animator.Play("Debut_2");
        Debug.Log(this);
    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {
    }
}


public class BossDebut1_3State : IState
{
    private BossFSM m_Boss;

    public BossDebut1_3State(BossFSM enemy)
    {
        m_Boss = enemy;
    }

    public void OnEnter()
    {
        UIManager.Instance.GetUI<BossHpItemUI>("BossHpItemUI").SetName("球");
        UIManager.Instance.GetUI<BossHpItemUI>("BossHpItemUI").SetMax(100);
        m_Boss.animator.Play("Debut_3");
        Debug.Log(this);
    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {
    }
}



public class BossIdle1_1State : IState
{
    private float timer = 0f;
    private BossFSM m_Boss;
    public BossIdle1_1State(BossFSM enemy)
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
        timer += Time.deltaTime;
        if (timer >= 5f)
        {
            timer = 0f;
            m_Boss.TransformState(BossStateType.Attack_1_1);
        }

        if (UIManager.Instance.GetUI<BossHpItemUI>("BossHpItemUI").Value <= 0)
        {
            m_Boss.TransformState(BossStateType.Death_1_1);
        }
    }
    public void OnExit()
    {       
    }
}

public class BossIdle1_2State : IState
{
    private BossFSM m_Boss;
    private float timer = 0f;
    public BossIdle1_2State(BossFSM enemy)
    {
        m_Boss = enemy;
    }
    public void OnEnter()
    {
        m_Boss.animator.Play("Idle_2");
        Debug.Log("Boss状态" + this);
    }
    public void OnUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= 5f)
        {
            timer = 0f;
            m_Boss.TransformState(BossStateType.Attack_1_2);
        }
    }
    public void OnExit()
    {
    }
}

public class BossIdle1_3State : IState
{
    private BossFSM m_Boss;
    private float timer = 0f;
    public BossIdle1_3State(BossFSM enemy)
    {
        m_Boss = enemy;
    }
    public void OnEnter()
    {
        m_Boss.animator.Play("Idle_3");
        Debug.Log("Boss状态" + this);
    }
    public void OnUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= 5f)
        {
            timer = 0f;
            m_Boss.TransformState(BossStateType.Attack_1_3);
        }
    }
    public void OnExit()
    {

    }
}
public class BossAttack1_1State : IState//攻击过程中不可打断
{

    //该阶段会使用的技能
    private int skill;

    private BossFSM m_Boss;
    public BossAttack1_1State(BossFSM enemy)
    {
        m_Boss = enemy;
    }


    public void OnEnter()
    {
        skill = Random.Range(1, 3);
        m_Boss.animator.Play("Attack_1");
        Debug.Log("Boss状态" + this);

        switch (skill)
        {
            case 1: m_Boss.Invoke("State1Skill_1", 0); break;
            case 2: m_Boss.Invoke("State1Skill_2", 0); break;
            case 3: m_Boss.Invoke("State1Skill_3", 0); break;
            default: break;
        }
    }

    public void OnUpdate()
    {

    }


    public void OnExit()
    {

    }
}
public class BossAttack1_2State : IState//攻击过程中不可打断
{
    float timer = 0f;
    private BossFSM m_Boss;
    public BossAttack1_2State(BossFSM enemy)
    {
        m_Boss = enemy;
    }


    public void OnEnter()
    {
        m_Boss.animator.Play("Attack_2");
        Debug.Log("Boss状态" + this);
        int skill = Random.Range(1, 3);
        switch (skill)
        {
            case 1: m_Boss.Invoke("State2Skill_1", 0); break;
            case 2: m_Boss.Invoke("State2Skill_2", 0); break;
            case 3: m_Boss.Invoke("State2Skill_3", 0); break;
            default: break;
        }
    }

    public void OnUpdate()
    {
        timer += Time.deltaTime;
        int skill = Random.Range(1, 3);
        if (timer >= 5f)
        {

        }
    }

    public void OnExit()
    {

    }
}
public class BossAttack1_3State : IState//攻击过程中不可打断
{
    float timer = 0f;
    private BossFSM m_Boss;
    public BossAttack1_3State(BossFSM enemy)
    {
        m_Boss = enemy;
    }


    public void OnEnter()
    {
        m_Boss.animator.Play("Attack_3");
        Debug.Log("Boss状态" + this);
        int skill = Random.Range(1, 3);
        switch (skill)
        {
            case 1: m_Boss.Invoke("State3Skill_1", 0); break;
            case 2: m_Boss.Invoke("State3Skill_2", 0); break;
            case 3: m_Boss.Invoke("State3Skill_3", 0); break;
            default: break;
        }
    }

    public void OnUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= 5f)
        {
        }
    }

    public void OnExit()
    {

    }
}

public class BossGetHit1_1State : IState
{
    private BossFSM m_Boss;

    public BossGetHit1_1State(BossFSM enemy)
    {
        m_Boss = enemy;
    }


    public void OnEnter()
    {
        m_Boss.animator.Play("GetHit_1");
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

public class BossGetHit1_2State : IState
{ 
    private BossFSM m_Boss;

    public BossGetHit1_2State(BossFSM enemy)
    {
        m_Boss = enemy;
    }


    public void OnEnter()
    {
        m_Boss.animator.Play("GetHit_2");
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

public class BossGetHit1_3State : IState
{
    private BossFSM m_Boss;

    public BossGetHit1_3State(BossFSM enemy)
    {
        m_Boss = enemy;
    }


    public void OnEnter()
    {
        m_Boss.animator.Play("GetHit_3");
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

public class BossDeath1_1State : IState
{
    private BossFSM m_Boss;

    public BossDeath1_1State(BossFSM enemy)
    {
        m_Boss = enemy;
    }

    public void OnEnter()
    {
        m_Boss.animator.Play("Death_1");
        Debug.Log(this);
    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {
    }
}

public class BossDeath1_2State : IState
{
    private BossFSM m_Boss;

    public BossDeath1_2State(BossFSM enemy)
    {
        m_Boss = enemy;
    }

    public void OnEnter()
    {
        m_Boss.animator.Play("Death_2");
        Debug.Log(this);
    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {
    }
}


public class BossDeath1_3State : IState
{
    private BossFSM m_Boss;

    public BossDeath1_3State(BossFSM enemy)
    {
        m_Boss = enemy;
    }

    public void OnEnter()
    {
        m_Boss.animator.Play("Death_3");
        Debug.Log(this);
    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {
        UIManager.Instance.CloseUI("BossHpItemUI");
    }
}





