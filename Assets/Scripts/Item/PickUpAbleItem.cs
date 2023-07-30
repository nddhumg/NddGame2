using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUpAbleItem : NddBehaviour {
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
	public virtual void PickUpAble(){
		itemCtrl.DestroyItem.DestroyObject ();
		this.ActiveItemWhenPickUp ();
	}
	protected abstract void ActiveItemWhenPickUp ();
}
