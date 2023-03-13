using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//小怪  状态 Idle,Patrol,Chase,Attack,GetHit,Death
//Boss 状态 Idle,Chase,Attack,Death
public class EnemyState : IState//Idle状态
{
    private EnemyFSM m_Enemy;
    private float timer;
    
    public EnemyState(EnemyFSM enemy)
    {
        m_Enemy = enemy;
    }
    
    public void OnEnter()
    {
        m_Enemy.animator.Play("Idle");
        Debug.Log(this);
    }

    public void OnUpdate()
    {
        //TODO 进入房间后，可以行动
        timer += Time.deltaTime;
        
        if(m_Enemy.getHit)
            m_Enemy.TransformState(StateType.GetHit);
        
        if(timer>=m_Enemy.GetPatrolTime())
            m_Enemy.TransformState(StateType.Patrol);
    }

    public void OnExit()
    {
        timer = 0;
    }
}

public class PatrolState : IState
{
    private EnemyFSM m_Enemy;
    
    public PatrolState(EnemyFSM enemy)
    {
        m_Enemy = enemy;
    }
    
    public void OnEnter()
    {
        m_Enemy.animator.Play("Move");
        m_Enemy.ChoosePatrolTarget();
        Debug.Log(this);
    }

    public void OnUpdate()
    {
        if ((m_Enemy.Player.transform.position - m_Enemy.transform.position).magnitude < m_Enemy.enemyInfo.FindRange)//玩家与敌人距离小于索敌距离
        {
            m_Enemy.TransformState(StateType.Chase);
        }
        
        if (((Vector2) m_Enemy.transform.position - m_Enemy.targetPos).magnitude > m_Enemy.agent.stoppingDistance)//敌人距离目标点距离大于停止距离
        {
            m_Enemy.agent.SetDestination(m_Enemy.targetPos);
        }
        else
        {
            m_Enemy.TransformState(StateType.Idle);
        }
    }

    public void OnExit()
    {
        
    }
}

public class ChaseState : IState
{
    private EnemyFSM m_Enemy;

    public ChaseState(EnemyFSM enemy)
    {
        m_Enemy = enemy;
    }
    
    public void OnEnter()
    {
        m_Enemy.animator.Play("Move");
        Debug.Log(this);
    }

    public void OnUpdate()
    {
        m_Enemy.targetPos = m_Enemy.Player.transform.position;
        m_Enemy.FlipTo();
        m_Enemy.agent.SetDestination(m_Enemy.targetPos);

        if (m_Enemy.getHit)
        {
            m_Enemy.TransformState(StateType.GetHit);
        }

        RaycastHit2D hit2D = Physics2D.Raycast(m_Enemy.transform.position,
            m_Enemy.targetPos - (Vector2) m_Enemy.transform.position);
        
        if (((Vector2)m_Enemy.transform.position - m_Enemy.targetPos).magnitude <
            0.9f * m_Enemy.enemyInfo.AttackRange&& hit2D&&hit2D.collider.CompareTag("Player"))
        { 
            m_Enemy.TransformState(StateType.Attack);
        }
        
        if (((Vector2) m_Enemy.transform.position - m_Enemy.targetPos).magnitude > m_Enemy.enemyInfo.FindRange)
        {
            m_Enemy.TransformState(StateType.Patrol);
        }
        
        
    }

    public void OnExit()
    {
        
    }
}

public class AttackState : IState//攻击过程中不可打断
{
    private EnemyFSM m_Enemy;
    
    public AttackState(EnemyFSM enemy)
    {
        m_Enemy = enemy;
    }

    public void OnEnter()
    {
        m_Enemy.animator.Play("Attack");
        Debug.Log(this);
        m_Enemy.FlipTo();
        m_Enemy.agent.Stop();
    }

    public void OnUpdate()
    {
        //切换至移动状态
        if (m_Enemy.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95f)
        {
            if((m_Enemy.Player.transform.position - m_Enemy.transform.position).magnitude < m_Enemy.enemyInfo.FindRange)
                m_Enemy.TransformState(StateType.Chase);
            else
                m_Enemy.TransformState(StateType.Patrol);
        }
    }

    public void OnExit()
    {
        
    }
}

public class GetHitState : IState
{
    private EnemyFSM m_Enemy;
    
    public GetHitState(EnemyFSM enemy)
    {
        m_Enemy = enemy;
        Debug.Log(this);
    }
    
    public void OnEnter()
    {
        m_Enemy.animator.Play("GetHit");
    }

    public void OnUpdate()
    {
        //受击函数
    }

    public void OnExit()
    {
        m_Enemy.getHit = false;
    }
}

public class DeathState : IState
{
    private EnemyFSM m_Enemy;
    
    public DeathState(EnemyFSM enemy)
    {
        m_Enemy = enemy;
    }
    
    public void OnEnter()
    {
        m_Enemy.animator.Play("Death");
        Debug.Log(this);
    }

    public void OnUpdate()
    {
        
    }

    public void OnExit()
    {
    }
}


