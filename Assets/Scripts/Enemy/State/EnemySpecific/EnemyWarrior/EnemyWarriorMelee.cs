using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarriorMelee : EnemyMelee {
	EnemyWarriorStateManager enemy;
	public EnemyWarriorMelee(EnemyStateManager stateManager,StateMachine stateMachine,string animBoolName,EnemyWarriorStateManager enemy): base(stateManager,stateMachine,animBoolName){
		this.enemy = enemy;
	}
	public override void LogicUpdate ()
	{
		base.LogicUpdate ();
		stateManager.Flip ();
		if (!isInAttackRange && isAnimationFinished)
			stateMachine.ChangeState (enemy.moveState);
	} 
}
