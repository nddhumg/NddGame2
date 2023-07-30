using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : NddBehaviour {
	[SerializeField]protected FlyBullet flyBullet;
	[SerializeField]protected DestroyBullet destroyBullet;
	[SerializeField]protected DamageSender damageSender;
	[SerializeField]protected BulletSO bulletSO;

	public BulletSO BulletSO{
		get{
			return bulletSO;
		}
	}
	public DamageSender DamageSender{
		get{
			return damageSender;
		}
	}
	public FlyBullet FlyBullet{
		get{
			return flyBullet;
		}
	}
	public DestroyBullet DestroyBullet{
		get{
			return destroyBullet;
		}
	}
	protected override void LoadComponent(){
		this.LoadFlyBullet ();
		this.LoadDestroyBullet ();
		this.LoadDamageSenderBullet ();
		this.LoadBulletSO ();
	}
	protected virtual void LoadDamageSenderBullet(){
		if (this.damageSender != null)
			return;
		this.damageSender= GetComponentInChildren<DamageSender>();
		Debug.LogWarning ("Add DamageSenderBullet", gameObject);
	}
	protected virtual void LoadFlyBullet(){
		if (this.flyBullet != null)
			return;
		this.flyBullet= GetComponentInChildren<FlyBullet>();
		Debug.LogWarning ("Add FlyBullet", gameObject);
	}
	protected virtual void LoadDestroyBullet(){
		if (this.destroyBullet != null)
			return;
		this.destroyBullet= GetComponentInChildren<DestroyBullet>();
		Debug.LogWarning ("Add DestroyBullet", gameObject);
	}
	protected virtual void LoadBulletSO(){
		if (this.bulletSO != null)
			return;
		string resPath = "ScriptableObject/Bullet/" +	transform.name;
		this.bulletSO = Resources.Load<BulletSO> (resPath);
		Debug.LogWarning (transform.name + " LoadBulletSO " + resPath, gameObject);
	}
}
