using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
public class PickUpItem : NddBehaviour {
	[SerializeField]private CircleCollider2D circleCollider2D;
	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadCircleCollider2D ();
	}
	protected virtual void LoadCircleCollider2D(){
		if (this.circleCollider2D != null)
			return;
		this.circleCollider2D= GetComponent<CircleCollider2D>();
		Debug.LogWarning ("Add CircleCollider2D", gameObject);
		this.circleCollider2D.isTrigger = true;
		this.circleCollider2D.radius = 2f;
	}
}
