using System;
using FSM;
using UnityEngine;

public class Monster : MonoBehaviour {
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
    [SerializeField] float _moveSpeed = 1;

    StateMachine<State> _fsm;

    public Animator       Animator        => _animator;
    public SpriteRenderer SpriteRenderer => _spriteRenderer;

    public float MoveSpeed => _moveSpeed;

    void Start() {
        _fsm = new StateMachine<State>();
        _fsm.AddState(State.Chase, new Chase(this, new Timer()));
        _fsm.AddState(State.Death, new Death(gameObject));
        _fsm.AddTransition(new Transition<State>(State.Chase, State.Death, _ => !IsAlive()));
        _fsm.SetStartState(State.Chase);
        _fsm.Init();
    }

    void Update() => _fsm.OnLogic();

    public bool IsAlive() => _health > 0;
    public bool IsPlayerInEngageRange() => GameObject.FindGameObjectWithTag("Player");
}


public interface ITimer
{
    public float GetDeltaTime();
}

public class Timer:ITimer
{
    public float GetDeltaTime()
    {
        return Time.deltaTime;
    }
}

public class FakeTimer : ITimer
{
    public float DeltTime;

    public float GetDeltaTime()
    {
        return  DeltTime;
    }
}