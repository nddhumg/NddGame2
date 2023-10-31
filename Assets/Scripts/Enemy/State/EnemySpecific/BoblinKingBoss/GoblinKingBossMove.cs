using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinKingBossMove : EnemyMove {
	GoblinKingBossStateManager enemy;
	public GoblinKingBossMove(EnemyStateManager stateManager,StateMachine stateMachine,string animBoolName,GoblinKingBossStateManager enemy): base(stateManager,stateMachine,animBoolName){
		this.enemy = enemy;
	}
	public override void LogicUpdate ()
	{
		base.LogicUpdate ();
		if (isInStopDistance) {
			stateMachine.ChangeState (enemy.idleState);
		}
	}
}
