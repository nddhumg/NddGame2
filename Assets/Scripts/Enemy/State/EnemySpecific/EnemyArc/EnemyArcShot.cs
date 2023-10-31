using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcShot : EnemyShot {
	EnemyArcStateManager enemyArc;
	public EnemyArcShot(EnemyStateManager stateManager,StateMachine stateMachine,string animBoolName,EnemyArcStateManager enemy): base(stateManager,stateMachine,animBoolName){
		enemyArc = enemy;
	}
	public override void LogicUpdate ()
	{
		base.LogicUpdate ();
		if (isAnimationFinished)
			stateMachine.ChangeState(enemyArc.idleState);
	}

}
