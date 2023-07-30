using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShotAbility : BaseAbility {
	[Header ("Shot Ability") ]
	[SerializeField] protected Vector3 target;
	[SerializeField] protected Quaternion bulletRotation;

	protected virtual Transform ShootBullet(Vector3 pos){
		this.SetBulletTarget ();
		bulletRotation =  this.SetBulletRotation (target);
		string nameBullet = GetNameBullet();
		if (target == Vector3.zero) {
			return null;
		}
		Transform newBullet = SpawnBullet.Instance.Spawn (nameBullet, pos, bulletRotation);
		if (newBullet == null)
			return null;
		BulletCtrl bulletCtrl= newBullet.GetComponent<BulletCtrl>();
		bulletCtrl.FlyBullet.SetDirection(target);
		return newBullet;
	}
	protected abstract string GetNameBullet ();
	protected abstract void SetBulletTarget ();
	protected abstract Quaternion SetBulletRotation(Vector3 target);
}
