using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarriorMove : EnemyWarriorState {
	private float speed =1;
	private float rangeAttack;

	public EnemyWarriorMove(EnemyWarriorStateManager stateManager, string nameAnimator) : base(stateManager,nameAnimator){
		speed = stateManager.enemyCtrl.EnemySO.speed;
		rangeAttack = stateManager.enemyCtrl.EnemySO.attackRange;
	}

	public override void LogicUpdate (){
		base.LogicUpdate ();
		Moving ();
		if (IsReadyAttack()) {
			stateManager.ChangeState (stateManager.AttackState);
		} 
	}
	private bool IsReadyAttack(){
		float distanceFromTarget = Vector3.Distance (stateManager.transform.position, Player.Instance.GetPosition());
		return distanceFromTarget <= rangeAttack - 0.5f;

	}
	private void Moving()
	{
		Vector3 targetPosition = Player.Instance.GetPosition ();
		Vector3  direction = ( targetPosition - stateManager.transform.position).normalized;
		Vector3 newPosition =  stateManager.transform.position + direction * speed *Time.deltaTime;
		stateManager.transform.parent.parent.position = newPosition;
	}
}
