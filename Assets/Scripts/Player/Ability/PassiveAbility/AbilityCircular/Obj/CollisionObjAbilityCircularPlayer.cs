using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CapsuleCollider2D))]
public class CollisionObjAbilityCircularPlayer : NddBehaviour {
	[SerializeField] protected CapsuleCollider2D capsuleCollider2D;
	[SerializeField] protected Vector2 offsetCapsule = new Vector2(0f, 0f);
	[SerializeField] protected Vector2 sizeCapsule = new Vector2(0.56f, 0.9f);

	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadCapsuleCollider2D (); 
	}
	protected virtual void LoadCapsuleCollider2D(){
		if(this.capsuleCollider2D != null)
			return;
		this.capsuleCollider2D = GetComponent<CapsuleCollider2D> ();
		this.capsuleCollider2D.isTrigger = true;
		this.capsuleCollider2D.offset = offsetCapsule;
		this.capsuleCollider2D.size = sizeCapsule;
		Debug.Log("Add CapsuleCollider2D",gameObject);
	}
}
