public interface IState
{
    void OnEnter();

    void OnUpdate();

    void OnExit();
}

public enum StateType
{
    Idle, Patrol, Chase, Attack,GetHit, Death
}

public enum BossStateType
{
    //第一个Boss
    Debut1_1, Debut1_2,  Debut1_3,
    Idle_1_1,Idle_1_2,Idle_1_3, 
    Attack_1_1, Attack_1_2, Attack_1_3,
    GetHit_1_1, GetHit_1_2, GetHit_1_3,
    Death_1_1, Death_1_2,  Death_1_3,
    //第二个Boss
    Debut_2,
    Idle_2_1, Idle_2_2,Idle_2_3, 
    Frizzy_2, 
    Attack_2_1, Attack_2_2, Attack_2_3,
    GetHit_2_1,GetHit_2_2, 
    Death_2_1,Death_2_2
}

