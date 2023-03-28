public interface IState
{
    void OnEnter();

    void OnUpdate();

    void OnExit();
}

public enum StateType
{
    Idle,Patrol,Chase,Attack,GetHit,Death
    ,Attack1,Attack2,Attack3,Attack4,Attack5,Attack6,Attack7,Attack8
}

