using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityShot : ActiveAbility {
	[Header ("Shot Ability") ]
	[SerializeField] protected Vector3 firingDirection;
	[SerializeField] protected Quaternion bulletRotation;
	[SerializeField] protected float damage;
	public float Damage{
		get{ 
			return damage;
		}
	}
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
		ResetTiming ();
		return newBullet;
	}
	public virtual void SetDelayShot(float delayShot){
		this.delayAbility = delayShot;
	}
	public virtual void SetDamage(float damage){
		this.damage = damage;
	}
	protected abstract string GetNameBullet ();
	protected abstract void SetBulletTarget ();
	protected abstract Quaternion SetBulletRotation(Vector3 target);
}
