using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgSenderBullet : DamageSender {
	[SerializeField] protected BulletCtrl bulletCtrl;

	protected override void LoadComponent(){
		this.LoadBulletCtrl ();
		base.LoadComponent ();
	}
	protected override void ResetValueComponent ()
	{
		base.ResetValueComponent ();
		offsetCapsuleColliser = bulletCtrl.BulletSO.sizeCapsule.offsetCollider;
		sizeCapsuleColliser = bulletCtrl.BulletSO.sizeCapsule.sizeCollider;
	}
	protected virtual void LoadBulletCtrl(){
		if (this.bulletCtrl != null)
			return;
		this.bulletCtrl= transform.parent.GetComponent<BulletCtrl>();
		Debug.Log ("Add  BulletCtrl", gameObject);
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.transform.name == transform.name )
			return;
		if (col.transform.parent.tag == bulletCtrl.BulletSO.tagShooter) {
			return;
		}
		Send (col.transform.parent);
	}

	protected override void Send(DamageReceiver receiver) {
		base.Send (receiver);
		SpawnBullet.Instance.DesTroyPrefabs (transform.parent);
	}
}
