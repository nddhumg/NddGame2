using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Shoot : NddBehaviour {
	[SerializeField] protected int keyShot;
	[SerializeField] protected Vector3 bulletTarget;
	[SerializeField] protected Quaternion bulletRotation;
	[SerializeField] protected float delayShot = 0.6f;
	[SerializeField] protected float timerShot = 1f;


	protected virtual bool CheckIsShoting(){
		timerShot += Time.deltaTime;
		if (timerShot < delayShot || keyShot != 1)
			return false;
		return true;
	}
	protected virtual Transform ShootBullet(string nameBullet,Vector3 pos){
		this.SetBulletTarget ();
		bulletRotation =  this.SetBulletRotation (bulletTarget);

		Transform newBullet = SpawnBullet.Instance.Spawn (nameBullet, pos, bulletRotation);
		if (newBullet == null)
			return null;
		
		BulletCtrl bulletCtrl= newBullet.GetComponent<BulletCtrl>();
		bulletCtrl.FlyBullet.SetDirection(bulletTarget);
		bulletCtrl.Shooter = transform.parent;
		return newBullet;
	}


	protected abstract void SetBulletTarget ();
	protected abstract Quaternion SetBulletRotation(Vector3 target);
}
