using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcShoot : EnemyArcState {
	public  EnemyArcShoot(EnemyArcStateManager stateManager, string nameAnimator) : base(stateManager,nameAnimator){
	}
	public override void Enter ()
	{
		base.Enter ();
		SwitchRotationtheTarget ();
	}
	public override void LogicUpdate (){
		base.LogicUpdate ();
		if (isAnimationFinished)
			stateManager.ChangeState (stateManager.IdleState);
	}
	private void SwitchRotationtheTarget(){
		if (Player.Instance.GetPosition ().x > stateManager.transform.position.x) {
			stateManager.enemyArcCtrl.transform.localScale = new Vector3 (1f, 1f, 1f);
		} else {
			stateManager.enemyArcCtrl.transform.localScale = new Vector3 (-1f, 1f, 1f);
		}
	} 
}
