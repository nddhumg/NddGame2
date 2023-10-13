using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcMove : EnemyArcState {
	private float speed;
	private float shotingRange;

	public EnemyArcMove(EnemyArcStateManager stateManager, string nameAnimator) : base(stateManager,nameAnimator){
		speed = stateManager.enemyArcCtrl.EnemyArcSO.speed;
		shotingRange =  stateManager.enemyArcCtrl.EnemyArcSO.attackRange;
	}

	public override void Enter(){
		base.Enter ();
	}
	public override void Exit(){
		base.Exit ();
	}
	public override void LogicUpdate (){
		base.LogicUpdate ();
		SwitchRotationtheTarget ();
		Moving ();
		if (IsShootingPosition()){
			stateManager.ChangeState (stateManager.IdleState);
		}
	}

	private bool IsShootingPosition(){
		Vector3 targetPosition = Player.Instance.GetPosition ();
		float distanceFromTarget = Vector3.Distance (stateManager.transform.position,targetPosition);
		return distanceFromTarget <= shotingRange - 5;
	}
	private void Moving()
	{
		Vector3 targetPosition = Player.Instance.GetPosition ();
		Vector3  direction = (targetPosition- stateManager.transform.position).normalized;
		Vector3 newPosition = stateManager.transform.parent.parent.position+direction * speed * Time.deltaTime;
		stateManager.enemyArcCtrl.transform.position = newPosition;
	}
	private void SwitchRotationtheTarget(){
		if (Player.Instance.GetPosition ().x > stateManager.transform.position.x) {
			stateManager.enemyArcCtrl.transform.localScale = new Vector3 (1f, 1f, 1f);
		} else {
			stateManager.enemyArcCtrl.transform.localScale = new Vector3 (-1f, 1f, 1f);
		}
	} 
}
