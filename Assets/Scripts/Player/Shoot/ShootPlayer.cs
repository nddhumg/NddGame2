using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : Shoot {
	[SerializeField] protected float ranShotBullet1 =0.05f;
	protected virtual void Update(){

		this.GetKeyShot ();
		this.Shoting ();
	}
	protected virtual void GetKeyShot(){
		keyShot = (int)InputManager.Instance.KeyShoot.x;
	}
	protected virtual void Shoting(){
		if (!CheckIsShoting()) {
			return;
		}
		timerShot = 0f;
		string nameBullet = RandomBullet();
		ShootBullet(nameBullet,transform.position);
	}
	protected virtual string RandomBullet(){
		float ran= Random.Range (0, 1f);
		if (ran > ranShotBullet1) {
			return SpawnBullet.Instance.Bullet2;
		} else {
			return SpawnBullet.Instance.Bullet1;
		}
	}
	protected override void SetBulletTarget(){
		bulletTarget = InputManager.Instance.PosMouse;
		bulletTarget -= transform.position;
		bulletTarget = new Vector3 (bulletTarget.x, bulletTarget.y, 0);
	}
	protected override Quaternion SetBulletRotation(Vector3 target){
		Quaternion rotNew = Quaternion.identity;
		float newRotz =  Vector3.SignedAngle (target, Vector3.right,Vector3.forward);
		rotNew *= Quaternion.Euler (0, 0,-newRotz);
		return rotNew;

	}
}
