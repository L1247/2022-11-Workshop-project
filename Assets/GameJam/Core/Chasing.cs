#region

using FSM;
using GameJam.Core;
using UnityEngine;

#endregion

public class Chasing : State<string>
{
#region Private Variables

    private readonly Monster1 monster1;
    // private readonly float    moveSpeed;
    private readonly float    stopDistance = 0.1f;
    private          int      deltaTime;

#endregion

#region Constructor

    public Chasing(Monster1 monster1) //, float moveSpeed)
    {
        this.monster1  = monster1;
        // this.moveSpeed = moveSpeed;
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
        var dir                = (targetPosition - monsterPos).normalized;
        var distanceWithTarget = Vector2.Distance(targetPosition , monsterPos);
        var needStop           = distanceWithTarget <= stopDistance;
        if (needStop) return;

        var time = deltaTime != 1 ? Time.deltaTime : deltaTime;

        var moveSpeed          = monster1.GetMoveSpeed();
        var movement           = monsterPos + dir * moveSpeed * time;
        var newDistance        = Vector2.Distance(targetPosition , movement);
        var overOriginDistance = newDistance >= distanceWithTarget;
        var finalPosition      = overOriginDistance ? targetPosition : movement;
        monster1.SetPos(finalPosition);

        var facingRight = dir.x > 0;
        monster1.SetFacing(facingRight ? Facing.Right : Facing.Left);
    }

    public void SetDeltaTime(int deltaTime)
    {
        this.deltaTime = deltaTime;
    }

#endregion
}