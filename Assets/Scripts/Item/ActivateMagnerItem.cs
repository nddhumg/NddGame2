using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActivateMagnerItem : NddBehaviour {
	[SerializeField]protected float speedMove = 10f;
	[SerializeField]protected bool isActivateMagner;
	void FixedUpdate(){
		if (isActivateMagner) {
			MoveToPlayer ();
		}
	}
	protected virtual void MoveToPlayer(){
		transform.parent.position = Vector3.MoveTowards (transform.position, Player.Instance.GetPosition (), speedMove * Time.fixedDeltaTime);
	}
	protected void ActivateMagner(){
		isActivateMagner = true;
	}
	protected virtual void OnDisable(){
		isActivateMagner = false;
	}
}
