using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DmgSenderObjAbilityCircular : DamageSender {
	protected override void ResetValue ()
	{
		base.ResetValue ();
		offsetCapsuleColliser = new Vector2(0f, 0f);
		sizeCapsuleColliser = new Vector2(0.56f, 0.9f);
	}
	void OnTriggerEnter2D(Collider2D col){
		Send (col.transform.parent);
	}
}
