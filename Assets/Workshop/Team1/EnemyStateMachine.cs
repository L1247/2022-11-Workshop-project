using System;
using FSM;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour{
	private StateMachine<EnemyState>            _stateMachine;
	public  Transform                           target;
	public  Animator                            animator;

	private void Start(){
		_stateMachine = new StateMachine<EnemyState>();
		_stateMachine.AddState(EnemyState.Chase, new Chase(transform, target));
		_stateMachine.AddState(EnemyState.Death, new Death(animator));
		_stateMachine.SetStartState(EnemyState.Chase);
		_stateMachine.Init();
	}

	private void Update(){
		_stateMachine.OnLogic();
	}
}

internal class Death : State<EnemyState>
{
	private readonly Animator animator;

	public Death(Animator animator)
	{
		this.animator = animator;
	}


	public override void OnEnter()
	{
		animator.Play("Death");
	}
}

public enum EnemyState{
	Chase,
	Death
}