using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : EnemyState {
	public EnemyMove(EnemyStateManager stateManager,StateMachine stateMachine,string animBoolName): base(stateManager,stateMachine,animBoolName){
	}
	public override void LogicUpdate ()
	{
		base.LogicUpdate ();
		stateManager.FolowingPlayer ();
	}
}
