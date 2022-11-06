
using FSM;
using UnityEngine;

namespace Workshop.Team3
{
    public class Chase :State<MonsterStateMachine.MonsterState>
    {
        private MonsterStateMachine monsterStateMachine;
        
        private GameObject     player_;

        public Chase(MonsterStateMachine monsterStateMachine)
        {
            this.monsterStateMachine = monsterStateMachine;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            Debug.Log("Chase");

            if (player_ == null)
                player_ = GameObject.FindGameObjectWithTag("Player");

            monsterStateMachine.SetAnimBool("IsChase", true);
        }

        public override void OnLogic()
        {
            base.OnLogic();

            if (player_ == null)
            {
                Debug.Log("cannot find player");
                return;
            }
            
            Move(player_.transform.position);
            Flip(player_.transform.position);
        }

        private void Move(Vector3 destination)
        {
            var moveDelta = (destination - monsterStateMachine.GetPosition()).normalized * 1 * Time.deltaTime;
            
            monsterStateMachine.SetPosition(moveDelta);
        }
        
        private void Flip(Vector3 destination)
        {
            var IsFlip = (destination.x - monsterStateMachine.GetPosition().x) < 0;
            
            monsterStateMachine.SetFlip(IsFlip);
        }
    }
}