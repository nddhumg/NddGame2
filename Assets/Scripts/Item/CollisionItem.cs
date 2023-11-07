using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class CollisionItem : NddBehaviour {
	[SerializeField]private ItemCtrl itemCtrl;
	[SerializeField]private CapsuleCollider2D capsuleCollider2D;

	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadItemCtrl ();
		this.LoadCapsuleCollider2D ();
	}
	protected virtual void LoadItemCtrl(){
		if (this.itemCtrl != null)
			return;
		this.itemCtrl= transform.parent.GetComponent<ItemCtrl>();
		Debug.LogWarning ("Add ItemCtrl", gameObject);
	}
	protected virtual void LoadCapsuleCollider2D(){
		if (this.capsuleCollider2D != null)
			return;
		this.capsuleCollider2D= GetComponent<CapsuleCollider2D>();
		Debug.LogWarning ("Add CapsuleCollider2D", gameObject);
		this.capsuleCollider2D.size =itemCtrl.ItemSO.sizeCapsule.sizeCollider;
		this.capsuleCollider2D.offset =itemCtrl.ItemSO.sizeCapsule.offsetCollider;
		this.capsuleCollider2D.isTrigger = true;
	}
}
