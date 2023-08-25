using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEnemy : ShotAbility {
	[Header("Shot Enemy")]
	[SerializeField] protected string nameTarget = "Player";
	[SerializeField] protected float range = 20f;
	[SerializeField] protected EnemyArcCtrl enemyArcCtrl;
	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadEnemyArcCtrl();
	}
	protected virtual void LoadEnemyArcCtrl(){
		if (this.enemyArcCtrl != null)
			return;
		this.enemyArcCtrl = transform.parent.parent.GetComponent<EnemyArcCtrl>();
		Debug.Log ("Add EnemyArcCtrl", gameObject);
	}
	 void FixedUpdate(){
		this.Shooting();
	}
	protected override void ResetValue(){
		base.ResetValue ();
		this.delayAbility = 2f;
		this.damage = enemyArcCtrl.EnemySO.damage;
	}
	protected virtual bool WithinFiringRange(){
		if (enemyArcCtrl.EnemyFollow.IsFollowing)
			return false;
		else {
			return true;
		}
	}
	protected virtual void Shooting(){
		if (!isReady )
			return;
		if (!WithinFiringRange ())
			return;
		timerAbility = 0f;
		enemyArcCtrl.AnimationEnemyArc.SetAnimationAttack ();
		//ShootBullet(transform.position);
	}

	protected override string GetNameBullet(){
		return enemyArcCtrl.EnemyArcSO.nameBulletShot.ToString();
	}
	protected override void SetBulletTarget(){
		Transform TfTarget = GameObject.Find (nameTarget).transform;
		firingDirection = TfTarget.position;
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
