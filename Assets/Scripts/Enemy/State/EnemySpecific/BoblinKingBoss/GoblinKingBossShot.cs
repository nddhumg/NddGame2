using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinKingBossShot : EnemyShot {
	GoblinKingBossStateManager enemy;
	public GoblinKingBossShot(EnemyStateManager stateManager,StateMachine stateMachine,string animBoolName,GoblinKingBossStateManager enemy) : base(stateManager,stateMachine,animBoolName){
		this.enemy = enemy;
	}
	public override void LogicUpdate ()
	{
		base.LogicUpdate ();
		if (isAnimationFinished)
			stateMachine.ChangeState (enemy.idleState);
	}
}
