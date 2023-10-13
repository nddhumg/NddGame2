using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarriorAttack : EnemyWarriorState {
	private float rangeAttack;

	public EnemyWarriorAttack(EnemyWarriorStateManager stateManager, string nameAnimator) : base(stateManager,nameAnimator){
		rangeAttack = stateManager.enemyCtrl.EnemySO.attackRange;
	}

	public override void LogicUpdate (){
		base.LogicUpdate ();

		if (!IsReadyAttack()) {
			if(isAnimationFinished)
			stateManager.ChangeState (stateManager.MoveState);
		} 
	}

	private bool IsReadyAttack(){
		float distanceFromPlayer = Vector3.Distance (stateManager.transform.position,Player.Instance.GetPosition());
		return distanceFromPlayer <= rangeAttack;
	}

}
