using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class ColiderExp : AbstractExp {
	[SerializeField]private CapsuleCollider2D capsuleCollider2D;
	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadCapsuleCollider2D ();
	}
	protected virtual void LoadCapsuleCollider2D(){
		if (this.capsuleCollider2D != null)
			return;
		this.capsuleCollider2D= GetComponent<CapsuleCollider2D>();
		Debug.LogWarning ("Add CapsuleCollider2D", gameObject);
		this.capsuleCollider2D.size =expCtrl.ExpSO.sizeCapsule.sizeCollider;
		this.capsuleCollider2D.offset =expCtrl.ExpSO.sizeCapsule.offsetCollider;
		this.capsuleCollider2D.isTrigger = true;
	}

}
