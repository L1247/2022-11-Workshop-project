#region

using FSM;
using UnityEngine;

#endregion

namespace StateMachine_Practice
{
    class Idle : State<NPCState>
    {
    #region Constructor

        public Idle() : base(needsExitTime : true) { }

    #endregion

    #region Events

        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("Idle");
        }

        public override void OnLogic()
        {
            if (timer.Elapsed >= 3)
                fsm.StateCanExit();
            // fsm.RequestStateChange(NPCState.WALK);
        }

    #endregion
    }
}