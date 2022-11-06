using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using Workshop.Team3;


public class Moster1StateMachine : MonoBehaviour
{
    public enum State
    {
        Chase,
    }
    
    private StateMachine<State> fsm;
    
    void Start()
    {
        fsm = new StateMachine<State>();
        fsm.AddState(State.Chase,new Chase());
        fsm.SetStartState(State.Chase);
        fsm.Init();
    }

    void Update()
    {
        fsm.OnLogic();
    }
}
