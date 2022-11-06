using FSM;
using UnityEngine;
using Workshop.Team2;

public class Chase : State<NPCState>
{
    private Character owner;
    private Character target;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    
    public Chase(Character _Owner, Character _Target) : base()
    {
        owner = _Owner;
        target = _Target;
        animator = owner.GetComponent<Animator>();
        spriteRenderer = owner.GetComponent<SpriteRenderer>();
    }

    public override void OnEnter()
    {
        animator.SetBool("isWalk", true);
    }

    public override void OnLogic()
    {
        // MoveTo(target.transform, Time.deltaTime);
        MoveTo(target.transform, Time.deltaTime);
    }

    public void MoveTo(Transform _Target, float tick)
    {
        if (Vector3.Distance(owner.transform.position , _Target.transform.position) > 0)
        {
            var dir = (_Target.position - owner.transform.position).normalized;
            owner.transform.position += dir * owner.Speed * tick;
            // owner.transform.Translate(dir * owner.Speed * tick);
            if (spriteRenderer != null)
            {
                spriteRenderer.flipX = dir.x < 0;
            }
        }
    }
}