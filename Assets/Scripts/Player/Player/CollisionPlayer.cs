using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class CollisionPlayer : CollisionManager {
	[SerializeField] protected BoxCollider2D boxCollider2D;
	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadBoxCollider2D ();
	}
	protected virtual void LoadBoxCollider2D(){
		if(this.boxCollider2D != null)
			return;
		this.boxCollider2D = GetComponent<BoxCollider2D> ();
		this.boxCollider2D.isTrigger = false;
		this.boxCollider2D.offset = new Vector2 (0f,-0.4f);
		this.boxCollider2D.size = new Vector2 (0.64f,1f);
		Debug.Log("Add BoxCollider2D",gameObject);
	}
}
