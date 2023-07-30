using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemCtrl : NddBehaviour {
	[SerializeField] protected DestroyItem destroyItem;
	public DestroyItem DestroyItem{
		get{
			return destroyItem;
		}
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadDestroyItem ();

	}
	protected virtual void LoadDestroyItem(){
		if (this.destroyItem != null)
			return;
		this.destroyItem= GetComponentInChildren<DestroyItem>();
		Debug.LogWarning ("Add DestroyItem", gameObject);
	}
}
