using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;

public enum StateTypes
{
    Death,
    Idle,
    Roaming,
    RunAway,
    Chasing,
    ChasingAndAttacking,
    Dashing,
}

public class FSMEntry : MonoBehaviour
{
    private StateMachine<StateTypes> _fsm;

    // Start is called before the first frame update
    void Start()
    {
        var playerData = new CharacterData();
        _fsm = new StateMachine<StateTypes>();
        
        // _fsm.AddState(StateTypes.Death, new DeathState());
        //_fsm.AddState(StateTypes.Idle, new IdleState());
        // _fsm.AddState(StateTypes.Roaming, new RoamingState());
        // _fsm.AddState(StateTypes.RunAway, new RunAwayState());
        _fsm.AddState(StateTypes.Chasing, new ChasingState(playerData));
        // _fsm.AddState(StateTypes.ChasingAndAttacking, new ChasingAndAttackingState());
        // _fsm.AddState(StateTypes.Dashing, new DashingState());
        
        _fsm.SetStartState(StateTypes.Idle);
        _fsm.Init();
    }

    // Update is called once per frame
    void Update()
    {
        _fsm.OnLogic();
    }
}

public class CharacterData
{
    public bool IsAlive;
    public bool IsPlayerInEngageRange;
    public bool IsPlayerInAttackRange;
    public bool IsPlayerInSafeRange;
    public bool IsAttackCooldown;
}