using FSM;
using UnityEngine;

public class Chase : State<EnemyState>
{
    private readonly float _moveSpeed;
    public Transform Origin { get; }
    public Transform Target { get; }

    public Chase(Transform origin, Transform target, float moveSpeed)
    {
        Origin = origin;
        Target = target;
        _moveSpeed = moveSpeed;
    }

    public override void OnEnter()
    {
        //play animation 
        Debug.Log($"Chasing");
    }

    public override void OnLogic()
    {
        ChasingTarget(Time.deltaTime);
    }

    public void ChasingTarget(float deltaTime)
    {
        var direction = (Origin.position - Target.position).normalized;
        Origin.position = direction * _moveSpeed * deltaTime;
    }
}