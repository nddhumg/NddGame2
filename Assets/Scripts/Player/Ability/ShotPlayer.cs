using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPlayer : ShotAbility {
	[Header ("Shot Ability Player")]
	[SerializeField] protected int keyShot;
	[SerializeField] protected float ranShotBullet1 =0.05f;
	[SerializeField] protected PlayerCtrl playerCtrl;
	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadPlayerCtrl (); 
	}

	protected virtual void LoadPlayerCtrl(){
		if (this.playerCtrl != null)
			return;
		this.playerCtrl= transform.GetComponentInParent<PlayerCtrl>();
		Debug.Log ("Add PlayerCtrl", gameObject);
	}
	protected override void ResetValue(){
		base.ResetValue ();
		this.delayAbility = 0.6f;
	}
	protected override void Update(){
		base.Update ();
		this.GetKeyShot ();
		this.Shooting ();
	}
	protected virtual void GetKeyShot(){
		keyShot = (int)InputManager.Instance.KeyShoot.x;
	}
	protected virtual void Shooting(){
		if (!isReady )
			return;
		if (keyShot != 1)
			return;
		timerAbility = 0f;
		Vector3 PosSpawn = transform.position + new Vector3 (0, -0.5f, 0);
		ShootBullet(PosSpawn);
	}
	protected override string GetNameBullet(){
		float ran= Random.Range (0, 1f);
		if (ran > ranShotBullet1) {
			return playerCtrl.PlayerSO.nameBullets[1];
		} else {
			return playerCtrl.PlayerSO.nameBullets[0];
		}
	}
	protected override void SetBulletTarget(){
		target = InputManager.Instance.PosMouse;
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
