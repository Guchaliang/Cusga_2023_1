public interface IState
{
    void OnEnter();

    void OnUpdate();

    void OnExit();
}

public enum StateType
{
    Idle,Patrol,Chase,Attack,GetHit,Death
}

