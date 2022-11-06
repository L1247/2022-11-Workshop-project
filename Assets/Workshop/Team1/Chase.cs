using FSM;
using UnityEngine;

public class Chase : State<EnemyState>{
    public Transform Origin { get; }
    public Transform Target { get; }

    public Chase(Transform origin, Transform target){
        Origin = origin;
        Target = target;
    }

    public override void OnEnter() {
        //play animation 
        Debug.Log($"Chasing");
    }

    public override void OnLogic()
    {
        ChasingTarget();
    }

    private void ChasingTarget() {
        Origin.position = Vector3.Lerp(Origin.position, Target.position, Time.deltaTime);
    }
}