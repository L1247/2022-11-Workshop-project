using FSM;
using UnityEngine;

public class Chase : State<Monster.State>
{
    static readonly int IsWalkHash = Animator.StringToHash("isWalk");
    Monster             _self;
    Transform           _player;
    Vector3             _orientation;

    public Chase(Monster self) => _self = self;

    public override void OnEnter()
    {
        base.OnEnter();
        if (_self.Animator != null)
            _self.Animator.SetBool(IsWalkHash, true);
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void OnLogic()
    {
        base.OnLogic();
        var start = _self.transform.position;
        var end   = _player.position;
        FaceToPlayer(start, end);
        MoveToPlayer((end - start).normalized);
    }

    public override void OnExit()
    {
        base.OnExit();
        _self.Animator.SetBool(IsWalkHash, false);
    }

    void FaceToPlayer(Vector3 start, Vector3 end)
    {
        if (_self.SpriteRenderer != null)
            _self.SpriteRenderer.flipX = start.x > end.x;
    }

    void MoveToPlayer(Vector3 front)
    {
        var time = _self.MoveSpeed * Time.deltaTime;
        _self.transform.position += front * time;
        Debug.Log($"time :{time}");
    }
}