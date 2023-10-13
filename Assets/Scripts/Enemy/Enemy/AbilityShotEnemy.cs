using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityShotEnemy : AbilityShot {
	[Header("Shot Enemy")]
	[SerializeField] protected EnemyArcCtrl enemyArcCtrl;
	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadEnemyArcCtrl();
	}
	protected virtual void LoadEnemyArcCtrl(){
		if (this.enemyArcCtrl != null)
			return;
		this.enemyArcCtrl = transform.parent.parent.parent.GetComponent<EnemyArcCtrl>();
		Debug.LogWarning ("Add EnemyArcCtrl", gameObject);
	}
	protected override void ResetValue(){
		base.ResetValue ();
		this.delayAbility = 2f;
	}
	protected override void ResetValueComponent ()
	{
		base.ResetValueComponent ();
		this.damage = enemyArcCtrl.EnemySO.damage;
	}
	protected override string GetNameBullet(){
		return enemyArcCtrl.EnemyArcSO.nameBulletShot.ToString();
	}
	protected override void SetBulletTarget(){
		Vector3 targetPosition = Player.Instance.GetPosition();
		firingDirection = targetPosition;
		firingDirection -= transform.position;
		firingDirection = new Vector3(firingDirection.x,firingDirection.y, 0);
	}
	protected override Quaternion SetBulletRotation(Vector3 target){
		Quaternion rotNew = Quaternion.identity;
		float newRotz =  Vector3.SignedAngle (target, Vector3.right,Vector3.forward);
		rotNew *= Quaternion.Euler (0, 0,-newRotz);
		return rotNew;

	}
}
