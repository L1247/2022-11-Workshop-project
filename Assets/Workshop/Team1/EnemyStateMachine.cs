using System;
using FSM;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour{
	private StateMachine<EnemyState> _stateMachine;
	public Transform target;

	private void Start(){
		_stateMachine = new StateMachine<EnemyState>();
		_stateMachine.AddState(EnemyState.Chase, new Chase(transform, target));
		_stateMachine.SetStartState(EnemyState.Chase);
		_stateMachine.Init();
	}

	private void Update(){
		_stateMachine.OnLogic();
	}
}

public class Chase : State<EnemyState>{
	public Transform Origin{ get; }
	public Transform Target{ get; }

	public Chase(Transform origin, Transform target){
		Origin = origin;
		Target = target;
	}

	public override void OnEnter(){
		//play animation 
		Debug.Log($"Chasing");
	}

	public override void OnLogic()
	{
		ChasingTarget();
	}

	private void ChasingTarget(){
		Origin.position = Vector3.Lerp(Origin.position, Target.position, Time.deltaTime);
	}
}

public enum EnemyState{
	Chase
}