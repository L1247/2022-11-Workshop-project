#region

using FSM;
using StateMachine_Practice;
using UnityEngine;

#endregion

public enum NPCState
{
    IDLE , WALK
}

public class NPCStateMachine : MonoBehaviour
{
    private StateMachine<NPCState> fsm;

    #region Private Variables

    // private StateMachine<NPCState> fsm;

#endregion

#region Unity events

    private void Start()
    {
        // fsm = new StateMachine<NPCState>();
        // fsm.AddState(NPCState.IDLE , new Idle());
        // fsm.AddState(NPCState.WALK , new Walk());
        // fsm.AddTransition(NPCState.IDLE , NPCState.WALK);
        // fsm.AddTransition(NPCState.WALK , NPCState.IDLE);
        // fsm.SetStartState(NPCState.IDLE);
        // fsm.Init();

        fsm = new StateMachine<NPCState>();
        fsm.AddState(NPCState.IDLE, new Idle());
        fsm.AddState(NPCState.WALK, new Walk());
        fsm.AddTransition(NPCState.IDLE, NPCState.WALK);
        fsm.AddTransition(NPCState.WALK, NPCState.IDLE);
        fsm.SetStartState(NPCState.IDLE);
        fsm.Init();
    }

#endregion

#region Private Methods

    private void Update()
    {
        fsm.OnLogic();
    }

#endregion
}