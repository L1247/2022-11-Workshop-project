#region

using FSM;
using UnityEngine;

#endregion

public class Chase : State<Monster.State>
{
#region Private Variables

    static readonly int IsWalkHash = Animator.StringToHash("isWalk");
    Monster             _self;
    Transform           _player;
    Vector3             _orientation;
    private ITimer      _selfTimer;

#endregion

#region Constructor

    public Chase(Monster self , ITimer timer)
    {
        _self      = self;
        _selfTimer = timer;
    }

#endregion

#region Public Methods

    public override void OnEnter()
    {
        base.OnEnter();
        if (_self.Animator != null)
            _self.Animator.SetBool(IsWalkHash , true);
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void OnExit()
    {
        base.OnExit();
        _self.Animator.SetBool(IsWalkHash , false);
    }

    public override void OnLogic()
    {
        base.OnLogic();
        var start = _self.transform.position;
        var end   = _player.position;
        FaceToPlayer(start , end);
        MoveToPlayer((end - start).normalized);
    }

#endregion

#region Private Methods

    void FaceToPlayer(Vector3 start , Vector3 end)
    {
        if (_self.SpriteRenderer != null)
            _self.SpriteRenderer.flipX = start.x > end.x;
    }

    void MoveToPlayer(Vector3 front)
    {
        var time = _self.MoveSpeed * _selfTimer.GetDeltaTime();
        _self.transform.position += front * time;
        // Debug.Log($"time :{time}");
    }

#endregion
}