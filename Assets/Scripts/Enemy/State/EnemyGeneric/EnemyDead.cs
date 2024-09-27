using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : EnemyState {
	public EnemyDead(EnemyStateManager stateManager,StateMachine stateMachine,string animBoolName): base(stateManager,stateMachine,animBoolName){
	}
}
