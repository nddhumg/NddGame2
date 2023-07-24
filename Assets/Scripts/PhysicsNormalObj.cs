using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PhysicsNormalObj : NddBehaviour {
	[SerializeField] protected Rigidbody2D rig2d;
	public Rigidbody2D Rig2d{
		get{
			return rig2d;
		}
	}
	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadRigidbody2D ();
	}
	protected virtual void LoadRigidbody2D(){
		if (this.rig2d != null)
			return;
		rig2d = GetComponent<Rigidbody2D> ();
		this.SetRigidbody2D ();
		Debug.Log ("Add LoadRigidbody2D", gameObject);
	}
	protected virtual void SetRigidbody2D(){
		//Override
	}
}
