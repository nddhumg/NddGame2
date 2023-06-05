using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSenderBullet : DamageSender {
	[SerializeField] protected BulletCtrl bulletCtrl;
	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadBulletCtrl ();
	}
	protected virtual void LoadBulletCtrl(){
		if (this.bulletCtrl != null)
			return;
		this.bulletCtrl= transform.parent.GetComponent<BulletCtrl>();
		Debug.Log ("Add  BulletCtrl", gameObject);
	}
	protected override void Send(DamageReceiver receiver) {
		bulletCtrl.DestroyBullet.DestroyObj ();
		base.Send (receiver);
	}
	protected override void ResetValue ()
	{
		base.ResetValue ();
		this.damage = bulletCtrl.BulletSO.damage;
	}
}
