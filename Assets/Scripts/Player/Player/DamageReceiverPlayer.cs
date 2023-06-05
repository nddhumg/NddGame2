using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(typeof(BoxCollider2D))]
public class DamageReceiverPlayer : DamageReceiver {
	//[SerializeField]protected BoxCollider2D boxCollider2D;
	public override void ResetHp(){
		base.ResetHp ();
	}
	protected override void ResetValue ()
	{
		base.ResetValue ();
		this.hpMax = 100f;
	}
	protected override void LoadComponent(){
		base.LoadComponent ();
		//this.LoadBoxCollider2D ();
	}
//	protected virtual void LoadBoxCollider2D(){
//		if (boxCollider2D != null)
//			return;
//		boxCollider2D = GetComponent<BoxCollider2D> ();
//		boxCollider2D.offset = new Vector2 (0f, -0.42f);
//		boxCollider2D.size = new Vector2 (0.6f, 1f);
//		Debug.Log ("Add BoxCollider2D", gameObject);
//	}
	protected override void OnDead ()
	{
		Debug.Log (transform.parent.name + "Dead", gameObject);
	}
}
