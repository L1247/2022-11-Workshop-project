#region

using System;
using FSM;
using UnityEngine;

#endregion

internal class Chasing : State<string>
{
    private Transform self;
    private float moveSpeed;
    private Transform target;
    private Animator animator;

    #region Constructor

    public Chasing(Transform self , Transform target , Animator animator , float moveSpeed)
    {
        this.self = self;
        this.target = target;
        this.animator = animator;
        this.moveSpeed = moveSpeed;
    }

    public override void OnLogic()
    {
        var _Dir = (target.position - self.position).normalized;
        self.Translate(_Dir * moveSpeed * Time.deltaTime);
        self.localScale = _Dir.x > 0 ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
    }

    #endregion
}