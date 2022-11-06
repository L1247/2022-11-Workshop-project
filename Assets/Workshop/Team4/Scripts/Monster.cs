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

    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Animator _animator;

    [SerializeField] float _health = 1;


    StateMachine<State> _fsm;

    void Start() {
        _fsm = new StateMachine<State>();
        _fsm.AddState(State.Chase, new Chase(transform, _spriteRenderer, _animator, 1f));
        _fsm.AddState(State.Death, new Death(gameObject));
        _fsm.AddTransition(new Transition<State>(State.Chase, State.Death, _ => !IsAlive()));
        _fsm.SetStartState(State.Chase);
        _fsm.Init();
    }

    void Update() => _fsm.OnLogic();

    public bool IsAlive() => _health > 0;
    public bool IsPlayerInEngageRange() => GameObject.FindGameObjectWithTag("Player");
}
