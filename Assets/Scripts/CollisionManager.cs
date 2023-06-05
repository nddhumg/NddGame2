using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : NddBehaviour {
//	[Header("ColliderManager")]
	//[SerializeField] protected Rigidbody2D rigTrigger2D;

	protected override void LoadComponent(){
		base.LoadComponent ();
		//this.LoadRigidbody2D ();
	}
//	protected virtual void LoadRigidbody2D(){
//		if (this.rigTrigger2D != null)
//			return;
//		rigTrigger2D = GetComponentInParent<Rigidbody2D> ();
//		Debug.Log ("Add Rigidbody2DP", gameObject);
//	}

}
