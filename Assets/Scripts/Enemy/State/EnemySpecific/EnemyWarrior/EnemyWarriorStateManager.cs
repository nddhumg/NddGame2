using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarriorStateManager : EnemyStateManager {

	public EnemyState moveState ;
	public EnemyState meleeState ;
	void OnEnable(){
		stateMachine.FirshState (moveState);
	}
	protected override void Awake(){
		moveState = new EnemyWarriorMove (this,stateMachine,"Move",this);
		meleeState = new EnemyWarriorMelee (this,stateMachine,"Melee",this);
	}
}
