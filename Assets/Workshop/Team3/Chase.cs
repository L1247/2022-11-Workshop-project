
using FSM;
using UnityEngine;

namespace Workshop.Team3
{
    public class Chase :State<MonsterStateMachine.MonsterState>
    {
        private Transform myTrans_;
        private GameObject player_;
        private SpriteRenderer spriteRenderer_;
        
        public Chase(Transform myTrans)
        {
            myTrans_ = myTrans;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("Chase");
            player_ = GameObject.FindGameObjectWithTag("Player");
            spriteRenderer_ = myTrans_.GetComponent<SpriteRenderer>();
        }

        public override void OnLogic()
        {
            base.OnLogic();
            Move(player_.transform.position);
            Flip(player_.transform.position);
        }

        private void Move(Vector3 destination)
        {
            myTrans_.position += (destination - myTrans_.position).normalized * 1 * Time.deltaTime;
        }
        
        private void Flip(Vector3 destination)
        {
            spriteRenderer_.flipX = (destination.x - myTrans_.position.x) < 0;
        }
    }
}