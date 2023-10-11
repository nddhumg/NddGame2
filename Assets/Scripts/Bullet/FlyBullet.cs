using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBullet : MoveInTheDirection {
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
	public virtual void SetDirection(Vector3 direction){
		this.direction = direction;
	}
	protected override void ResetValueComponent ()
	{
		base.ResetValue ();
		this.speed = bulletCtrl.BulletSO.speed;
	}
}
