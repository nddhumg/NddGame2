using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPlayer : PickUp {
	[SerializeField]protected PlayerCtrl playerCtrl;
	protected override void PickUpItem(Transform transformItem){
		PickUpAble pickUpAbleItem = transformItem.parent.GetComponentInChildren<PickUpAble> ();
		if (pickUpAbleItem == null)
			return;
		pickUpAbleItem.Collect (playerCtrl);
		pickUpAbleItem.Collect ();
	} 

	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadPlayerCtrl ();
	}

	protected virtual void LoadPlayerCtrl(){
		if (this.playerCtrl != null)
			return;
		this.playerCtrl= transform.GetComponentInParent<PlayerCtrl>();
		Debug.Log ("Add PlayerCtrl", gameObject);
	}
}
