using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShotAbility : ActiveAbility {
	[Header ("Shot Ability") ]
	[SerializeField] protected Vector3 firingDirection;
	[SerializeField] protected Quaternion bulletRotation;
	[SerializeField] protected float damage;

	public virtual Transform ShootBullet(Vector3 pos){
		this.SetBulletTarget ();
		bulletRotation =  this.SetBulletRotation (firingDirection);
		string nameBullet = GetNameBullet();
		if (firingDirection == Vector3.zero) {
			return null;
		}
		Transform newBullet = SpawnBullet.Instance.Spawn (nameBullet, pos, bulletRotation);
		if (newBullet == null)
			return null;
		BulletCtrl bulletCtrl= newBullet.GetComponent<BulletCtrl>();
		bulletCtrl.FlyBullet.SetDirection(firingDirection);
		bulletCtrl.DamageSender.SetDamage (damage);
		return newBullet;
	}
	protected abstract string GetNameBullet ();
	protected abstract void SetBulletTarget ();
	protected abstract Quaternion SetBulletRotation(Vector3 target);
}
