using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootAbility : BaseAbility {
	[Header ("Shoot Ability") ]
	[SerializeField] protected Vector3 target;
	[SerializeField] protected Quaternion bulletRotation;

	protected virtual Transform ShootBullet(string nameBullet,Vector3 pos){
		this.SetBulletTarget ();
		bulletRotation =  this.SetBulletRotation (target);

		Transform newBullet = SpawnBullet.Instance.Spawn (nameBullet, pos, bulletRotation);
		if (newBullet == null)
			return null;

		BulletCtrl bulletCtrl= newBullet.GetComponent<BulletCtrl>();
		bulletCtrl.FlyBullet.SetDirection(target);
		bulletCtrl.Shooter = transform.parent.parent;
		return newBullet;
	}

	protected abstract void SetBulletTarget ();
	protected abstract Quaternion SetBulletRotation(Vector3 target);
}
