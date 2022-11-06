using System;
using FSM;
using UnityEngine;

sealed class Monster : MonoBehaviour {
    public enum State {
        Chase,
        Death,
        Shoot,
        Retreat,
        Roam,
        Dash,

        [Obsolete("Do not use this", true)]
        Idle
    }

    StateMachine<State> _fsm;

    void Start() {
        _fsm = new StateMachine<State>();
        _fsm.AddState(State.Chase, new ChaseState(transform, 1f));
        _fsm.SetStartState(State.Chase);
        _fsm.Init();
    }

    void Update() => _fsm.OnLogic();

    public bool IsPlayerInEngageRange() => GameObject.FindGameObjectWithTag("Player");
}
