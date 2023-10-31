using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarriorMove : EnemyMove {
	EnemyWarriorStateManager enemy;
	public EnemyWarriorMove(EnemyStateManager stateManager,StateMachine stateMachine,string animBoolName,EnemyWarriorStateManager enemy): base(stateManager,stateMachine,animBoolName){
		this.enemy = enemy;
	}
	public override void LogicUpdate ()
	{
		base.LogicUpdate ();
		if (isInStopDistance)
			stateMachine.ChangeState (enemy.meleeState);
	}
}
