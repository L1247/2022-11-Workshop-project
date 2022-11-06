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

        public bool IsDeath;
        public bool IsPlayerAlive;

        private                  StateMachine<MonsterState> fsm;
        private                  Animator                   anim;
        [SerializeField] private SpriteRenderer             render;

        void Start()
        {
            anim = GetComponent<Animator>();

            fsm = new StateMachine<MonsterState>();
            fsm.AddState(MonsterState.Chase, new Chase(this, new TestTime()));
            fsm.SetStartState(MonsterState.Chase);
            fsm.Init();
        }

        void Update()
        {
            fsm.OnLogic();
        }

        public void SetPosition(Vector3 moveDelta) => transform.localPosition += moveDelta;
        public Vector3 GetPosition() => transform.localPosition;

        public void SetFlip(bool IsFlip) => render.flipX = IsFlip; 
        
        public void SetAnimBool(string animName, bool IsOn) => anim.SetBool(animName, IsOn);
    }
}