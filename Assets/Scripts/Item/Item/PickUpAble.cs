using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUpAble : NddBehaviour {
	
	public virtual void PickUp(PlayerCtrl playerCtrl){
		this.ActiveItemWhenPickUp (playerCtrl);
	}
	protected abstract void ActiveItemWhenPickUp (PlayerCtrl playerCtrl);
}
