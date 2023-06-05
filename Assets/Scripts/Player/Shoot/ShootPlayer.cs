using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : Shoot {
	[SerializeField] protected string bulletSkill = "Bullet1";
	[SerializeField] protected string bulletNormal = "Bullet2";
	[SerializeField] protected float DelayShotBulletNormal = 0.6f;
	[SerializeField] protected float timerShotBulletNormal = 1f;
	[SerializeField] protected float DelayShotBulletSkill = 7f;
	[SerializeField] protected float timerShotBulletSkill = 10f;
	protected virtual void UpdateKeyShot(){
		shooting = InputManager.Instance.KeyShoot;
	}

	protected virtual void Shot(string nameBullet,float isShot ,ref float timer,ref float delay){
		timer += Time.deltaTime;
		if (timer < delay || isShot !=1) 
			return;
		
		ShootBullet (nameBullet, transform.position);
		timer = 0f;
	}
	protected virtual void ShotNormal(){
		Shot(bulletNormal,shooting.x,ref timerShotBulletNormal,ref DelayShotBulletNormal);

	}
	protected virtual void ShotSkill(){
		Shot(bulletSkill,shooting.y,ref timerShotBulletSkill,ref DelayShotBulletSkill);
		// TODO bulletname in shot skill
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
	void Update(){
		this.UpdateKeyShot ();
		this.ShotNormal ();
		this.ShotSkill ();
	}


}
