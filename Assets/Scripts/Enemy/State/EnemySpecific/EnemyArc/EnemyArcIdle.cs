using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcIdle : EnemyIdle {
	EnemyArcStateManager enemyArc;
	protected bool isReadyShot;
	public EnemyArcIdle(EnemyStateManager stateManager,StateMachine stateMachine,string animBoolName,EnemyArcStateManager enemy): base(stateManager,stateMachine,animBoolName){
		enemyArc = enemy;
	}
	public override void LogicUpdate ()
	{
		base.LogicUpdate ();
		if (!isInAttackRange) {
			stateMachine.ChangeState (enemyArc.moveState);
		}
		else if (isInAttackRange && isReadyShot) {
			stateMachine.ChangeState (enemyArc.shotState);
		}
	}
	public override void DoChecks ()
	{
		base.DoChecks ();
		isReadyShot = enemyArc.CheckReadyShot ();
	}
}
