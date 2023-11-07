using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PickUpAbleExpMagnet : PickUpAble {
	[SerializeField]protected ItemCtrl itemCtrl;
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadItemCtrl ();

	}
	protected virtual void LoadItemCtrl(){
		if (this.itemCtrl != null)
			return;
		this.itemCtrl= transform.parent.GetComponent<ItemCtrl>();
		Debug.LogWarning ("Add ItemCtrl", gameObject);
	}
	public static event Action OnPickUp = delegate{ };

	public override void Collect ()
	{
		OnPickUp?.Invoke ();
		itemCtrl.DestroyItem.DestroyObject();;
	}
	protected override void ActiveItemWhenPickUp (PlayerCtrl playerCtrl){
		
	}
}
