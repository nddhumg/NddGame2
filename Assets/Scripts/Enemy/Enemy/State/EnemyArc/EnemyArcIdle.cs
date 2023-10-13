using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcIdle : EnemyArcState {
	private bool isReadyShoot;
	private float shootingRange;
	private float shootingDelayTime;

	public EnemyArcIdle(EnemyArcStateManager stateManager, string nameAnimator) : base(stateManager,nameAnimator){
		shootingRange =  stateManager.enemyArcCtrl.EnemyArcSO.attackRange;
		shootingDelayTime = stateManager.enemyArcCtrl.ShotEnemy.DelayAbility;
	}
	public override void Enter(){
		base.Enter ();
		isReadyShoot = false;
	}
	public override void Exit(){
		base.Exit ();
	}
	public override void LogicUpdate (){
		base.LogicUpdate ();

		CheckIfReadyShoot ();

		if (!IsShootingPosition()) {
			stateManager.ChangeState (stateManager.MoveState);
		} else if (isReadyShoot) {
			stateManager.ChangeState (stateManager.ShootState);
		}
	}

	private bool IsShootingPosition(){
		Vector3 targetPosition = Player.Instance.GetPosition ();
		float distanceFromTarget = Vector3.Distance (stateManager.transform.position,targetPosition);
		return distanceFromTarget <= shootingRange;
	}
	private void CheckIfReadyShoot(){
		if (!isReadyShoot && Time.time > startTime + shootingDelayTime)
			isReadyShoot = true;
	}
}
