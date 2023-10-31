using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcMove : EnemyMove {
	EnemyArcStateManager enemyArc;
	public EnemyArcMove(EnemyStateManager stateManager,StateMachine stateMachine,string animBoolName,EnemyArcStateManager enemy): base(stateManager,stateMachine,animBoolName){
		enemyArc = enemy;
	}
	public override void LogicUpdate(){
		base.LogicUpdate();
		if (isInStopDistance)
			stateMachine.ChangeState (enemyArc.idleState);
	}
}
