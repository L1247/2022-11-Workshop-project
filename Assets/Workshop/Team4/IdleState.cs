using FSM;
using UnityEngine;

internal class IdleState : State<StateTypes>
{
    public override void OnEnter()
    {
        Debug.Log("Idle");
    }

    public override void OnLogic()
    {
        // if(timer.Elapsed >1.5f)
        //     fsm.RequestStateChange();
    }
}