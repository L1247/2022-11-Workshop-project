using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using Workshop.Team3;

namespace Workshop.Team3
{
    public class MonsterStateMachine : MonoBehaviour
    {
        public enum MonsterState
        {
            Chase,
        }

        private StateMachine<MonsterState> fsm;

        void Start()
        {
            fsm = new StateMachine<MonsterState>();
            fsm.AddState(MonsterState.Chase, new Chase(transform));
            fsm.SetStartState(MonsterState.Chase);
            fsm.Init();
        }

        void Update()
        {
            fsm.OnLogic();
        }
    }
}