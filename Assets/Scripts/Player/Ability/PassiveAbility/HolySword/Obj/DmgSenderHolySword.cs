using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgSenderHolySword : DamageSender {
	protected override void ResetValue ()
	{
		base.ResetValue ();
		offsetCapsuleColliser = new Vector2(0.37f, 0f);
		sizeCapsuleColliser = new Vector2(0.54f, 0.54f);
	}
	void OnTriggerEnter2D(Collider2D col){

		Send (col.transform.parent);
	}
}
