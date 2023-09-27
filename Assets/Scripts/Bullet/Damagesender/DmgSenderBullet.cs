using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgSenderBullet : DamageSender {
	[SerializeField] protected BulletCtrl bulletCtrl;

	protected override void LoadComponent(){
		this.LoadBulletCtrl ();
		base.LoadComponent ();
	}
	protected virtual void LoadBulletCtrl(){
		if (this.bulletCtrl != null)
			return;
		this.bulletCtrl= transform.parent.GetComponent<BulletCtrl>();
		Debug.Log ("Add  BulletCtrl", gameObject);
	}
	protected override void SetCapsuleCollider2D(){
		if(this.capsuleCollider2D != null)
			return;
		capsuleCollider2D.size = bulletCtrl.BulletSO.sizeCapsule.sizeCollider;
		capsuleCollider2D.offset = bulletCtrl.BulletSO.sizeCapsule.offsetCollider;
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
		receiver?.Receiver(this.damage);
		SpawnBullet.Instance.DesTroyPrefabs (transform.parent);
	}
}
