using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEnemy : ShotAbility {
	[Header("Shot Enemy")]
	[SerializeField] protected string nameTarget = "Player";
	[SerializeField] protected float range = 20f;
	[SerializeField] protected EnemyCtrl enemyCtrl;
	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadEnemyCtrl ();
	}
	protected virtual void LoadEnemyCtrl(){
		if (this.enemyCtrl != null)
			return;
		this.enemyCtrl = transform.parent.parent.GetComponent<EnemyCtrl>();
		Debug.Log ("Add EnemyCtrl", gameObject);
	}
	protected override void Update(){
		base.Update();
		this.Shooting();
	}
	protected override void ResetValue(){
		base.ResetValue ();
		this.delayAbility = 2f;
	}
	protected virtual bool WithinFiringRange(){
		if (enemyCtrl.EnemyFollow.IsFollowing)
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
		ShootBullet(transform.position);
	}

	protected override string GetNameBullet(){
		return enemyCtrl.EnemyArcSO.nameBulletShot;
	}
	protected override void SetBulletTarget(){
		Transform TfTarget = GameObject.Find (nameTarget).transform;
		target = TfTarget.position;
		target -= transform.position;
		target = new Vector3 (target.x, target.y, 0);
	}
	protected override Quaternion SetBulletRotation(Vector3 target){
		Quaternion rotNew = Quaternion.identity;
		float newRotz =  Vector3.SignedAngle (target, Vector3.right,Vector3.forward);
		rotNew *= Quaternion.Euler (0, 0,-newRotz);
		return rotNew;

	}
}
