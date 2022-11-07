#region

using FSM;
using UnityEngine;

#endregion

public class Chasing : State<string>
{
#region Private Variables

    private readonly Animator  animator;
    private readonly float     moveSpeed;
    private readonly string    chasingStateName = "Walk";
    private readonly Transform self;
    private readonly Transform target;

#endregion

#region Constructor

    public Chasing(Transform self , Transform target , Animator animator , float moveSpeed)
    {
        this.self      = self;
        this.target    = target;
        this.animator  = animator;
        this.moveSpeed = moveSpeed;
    }

#endregion

#region Events

    public override void OnEnter()
    {
        animator.Play(chasingStateName);
    }

    public override void OnLogic()
    {
        var moveDirection = (target.position - self.position).normalized;
        var movement      = moveDirection * /*Time.deltaTime*/ 1 * moveSpeed;
        self.position += movement;
    }

#endregion
}