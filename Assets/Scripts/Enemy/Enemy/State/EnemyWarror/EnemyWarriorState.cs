using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarriorState : BaseState {
	protected EnemyWarriorStateManager stateManager;
	public EnemyWarriorState (EnemyWarriorStateManager stateManager,string animBoolName) : base (animBoolName){
		this.stateManager = stateManager;
		this.animBoolName = animBoolName;
	}

	public override void Enter(){
		base.Enter ();
		stateManager.enemyCtrl.Animator.SetBool (animBoolName, true);
	}	
	public override void Exit(){
		stateManager.enemyCtrl.Animator.SetBool  (animBoolName, false);
	}
}
