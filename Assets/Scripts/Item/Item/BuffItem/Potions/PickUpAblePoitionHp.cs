using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAblePoitionHp : PickUpAble {
	[SerializeField]protected BuffItemCtrl buffItemCtrl;
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadBuffItemCtrl ();

	}
	protected virtual void LoadBuffItemCtrl(){
		if (this.buffItemCtrl != null)
			return;
		this.buffItemCtrl= transform.parent.GetComponent<BuffItemCtrl>();
		Debug.LogWarning ("Add BuffItemCtrl", gameObject);
	}

	protected override void ActiveItemWhenPickUp (PlayerCtrl playerCtrl){
		playerCtrl.DamageReceiver.AddHp(100f);
		buffItemCtrl.DestroyItem.DestroyObject ();
	}
}
