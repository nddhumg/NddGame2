using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcState : BaseState {
	protected EnemyArcStateManager stateManager;

	public EnemyArcState(EnemyArcStateManager stateManager, string nameAnimator): base(nameAnimator){
		this.stateManager = stateManager; 
		this.animBoolName = nameAnimator;
	}

	public override void Enter(){
		base.Enter ();
		stateManager.enemyArcCtrl.Animator.SetBool  (animBoolName, true);
	}	
	public override void Exit(){
		stateManager.enemyArcCtrl.Animator.SetBool  (animBoolName, false);
	}
}
