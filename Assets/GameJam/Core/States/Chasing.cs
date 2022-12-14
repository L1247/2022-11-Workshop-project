#region

using FSM;
using UnityEngine;

#endregion

namespace GameJam.Core.States
{
    public class Chasing : State<string>
    {
    #region Private Variables

        private readonly Monster1 monster1;
        private          float    stopDistance = 0.1f;
        private          float    deltaTime;

    #endregion

    #region Constructor

        public Chasing(Monster1 monster1)
        {
            this.monster1 = monster1;
        }

    #endregion

    #region Public Methods

        public override void OnEnter()
        {
            monster1.PlayAnimation("Chasing");
        }

        public override void OnLogic()
        {
            var target   = monster1.GetTarget();
            var noTarget = target == null;
            if (noTarget) return;

            var targetPosition     = target.position;
            var monsterPos         = monster1.GetPos();
            var dir                = targetPosition - monsterPos;
            var normalizedDir      = dir.normalized;
            var distanceWithTarget = Vector2.Distance(targetPosition , monsterPos);
            var needStop           = distanceWithTarget <= stopDistance;
            if (needStop) return;

            var time = deltaTime != 1 ? Time.deltaTime : deltaTime;

            var moveSpeed          = monster1.GetMoveSpeed();
            var movement           = normalizedDir * moveSpeed * time;
            var overOriginDistance = movement.magnitude >= dir.magnitude;
            var finalPosition      = overOriginDistance ? targetPosition : movement + monsterPos;
            monster1.SetPos(finalPosition);

            var facingRight = normalizedDir.x > 0;
            monster1.SetFacing(facingRight ? Facing.Right : Facing.Left);
        }

        public void SetDeltaTime(float deltaTime)
        {
            this.deltaTime = deltaTime;
        }

        public void SetStopDistance(int value)
        {
            stopDistance = value;
        }

    #endregion
    }
}