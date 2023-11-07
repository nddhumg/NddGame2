using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUpAble : NddBehaviour {
	
	public virtual void Collect(PlayerCtrl playerCtrl){
		this.ActiveItemWhenPickUp (playerCtrl);
	}
	public virtual void Collect(){
	}
	protected abstract void ActiveItemWhenPickUp (PlayerCtrl playerCtrl);
}
