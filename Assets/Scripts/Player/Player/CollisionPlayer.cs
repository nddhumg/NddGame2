using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class CollisionPlayer : NddBehaviour {
	[Header("ColliderPlayer")]
	[SerializeField] protected CapsuleCollider2D capsuleCollider2D;
	[SerializeField] protected PlayerCtrl playerCtrl;
	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadPlayerCtrl ();
		this.LoadCapsuleCollider2D (); 
	}

	protected virtual void LoadPlayerCtrl(){
		if (this.playerCtrl != null)
			return;
		this.playerCtrl= transform.GetComponentInParent<PlayerCtrl>();
		Debug.Log ("Add PlayerCtrl", gameObject);
	}
	protected virtual void LoadCapsuleCollider2D(){
		if(this.capsuleCollider2D != null)
			return;
		this.capsuleCollider2D = GetComponent<CapsuleCollider2D> ();
		this.capsuleCollider2D.isTrigger = false;
		this.capsuleCollider2D.offset = playerCtrl.PlayerSO.offsetCollider;
		this.capsuleCollider2D.size = playerCtrl.PlayerSO.sizeCollider;
		Debug.Log("Add CapsuleCollider2D",gameObject);
	}
}
