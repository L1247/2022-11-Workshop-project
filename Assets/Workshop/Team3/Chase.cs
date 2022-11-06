
using FSM;
using UnityEngine;

namespace Workshop.Team3
{
    public class Chase :State<Moster1StateMachine.State>
    {
        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("Chase");
        }

        public override void OnLogic()
        {
            base.OnLogic();
        }
    }
}