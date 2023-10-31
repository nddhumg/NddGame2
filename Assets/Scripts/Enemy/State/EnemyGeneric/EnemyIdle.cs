using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : EnemyState {
	public EnemyIdle(EnemyStateManager stateManager,StateMachine stateMachine,string animBoolName): base(stateManager,stateMachine,animBoolName){
	}
	public override void Exit ()
	{
		base.Exit ();
		stateManager.Flip ();
	}
}
