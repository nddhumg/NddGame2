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
		SetAnimationEnter();
	}

	public override void Exit(){
		base.Exit ();
		SetAnimationExit();
	}

	public override void DoChecks ()
	{
		base.DoChecks ();
		isInAttackRange = stateManager.CheckPlayerWithinAttackRange ();
		isInStopDistance = stateManager.CheckDistanceStopMoveFormPlayer ();
	}

	public virtual void SetAnimationEnter(){
		stateManager.anim.SetBool (animName,true);
	}

	public virtual void SetAnimationExit(){
		stateManager.anim.SetBool (animName,false);
	}
}
