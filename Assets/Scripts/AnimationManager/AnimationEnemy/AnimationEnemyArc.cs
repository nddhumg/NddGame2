using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnemyArc : AnimationEnemy {
	[SerializeField]protected EnemyArcCtrl enemyArcCtrl;
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadEnemyArcCtrl ();
	}
	protected virtual void LoadEnemyArcCtrl(){
		if (this.enemyArcCtrl != null)
			return;
		enemyArcCtrl = transform.parent.parent.GetComponent<EnemyArcCtrl> ();
		Debug.LogWarning ("EnemySO convert to EnemyArcSO", gameObject);
	}
	public void ShootEnemyArc(){
		enemyArcCtrl.ShotEnemy.ShootBullet (transform.position);
	}

	public void SetAnimationAttack(){
		ani.SetTrigger ("Attack");
	}
}
