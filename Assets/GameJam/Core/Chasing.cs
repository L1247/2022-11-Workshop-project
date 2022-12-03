#region

using FSM;
using UnityEngine;

#endregion

internal class Chasing : State<string>
{
#region Private Variables

    private readonly Transform self;
    private readonly float     moveSpeed;
    private readonly Transform target;
    private readonly Animator  animator;
    private readonly float     stopDistance = 0.1f;
    private readonly Vector3   rightVector  = new Vector3(1 ,  1 , 1);
    private readonly Vector3   leftVector   = new Vector3(-1 , 1 , 1);

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

#region Public Methods

    public override void OnEnter()
    {
        animator.Play("Walk");
    }

    public override void OnLogic()
    {
        var targetPosition     = target.position;
        var selfPosition       = self.position;
        var dir                = (targetPosition - selfPosition).normalized;
        var distanceWithTarget = Vector2.Distance(targetPosition , selfPosition);
        var needStop           = distanceWithTarget <= stopDistance;
        if (needStop) return;
        self.Translate(dir * moveSpeed * Time.deltaTime);
        var facingRight = dir.x > 0;
        self.localScale = facingRight ? rightVector : leftVector;
    }

#endregion
}