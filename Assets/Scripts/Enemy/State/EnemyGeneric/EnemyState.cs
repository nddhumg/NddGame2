using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : BaseState {
	protected EnemyStateManager stateManager;

	protected bool isInAttackRange;
	protected bool isInStopDistance;

	public EnemyState(EnemyStateManager stateManager,StateMachine stateMachine,string animBoolName): base(stateMachine,animBoolName){
		this.stateManager = stateManager;
	}
	public override void Enter(){
		base.Enter ();
		stateManager.anim.SetBool (animBoolName,true);

	}
	public override void Exit(){
		base.Exit ();
		stateManager.anim.SetBool (animBoolName,false);
	}
	public override void DoChecks ()
	{
		base.DoChecks ();
		isInAttackRange = stateManager.CheckPlayerWithinAttackRange ();
		isInStopDistance = stateManager.CheckDistanceStopMoveFormPlayer ();
	}
}
