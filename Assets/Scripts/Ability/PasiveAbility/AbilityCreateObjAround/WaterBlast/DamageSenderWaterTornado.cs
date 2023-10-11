using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSenderWaterTornado : DamageSender {
	[SerializeField] protected float timer =1f;
	[SerializeField] protected float timeDelayAttack = 0.5f;
	void FixedUpdate(){
		if (timer < timeDelayAttack)
			timer += Time.fixedDeltaTime;
	}
	protected override void ResetValue ()
	{
		base.ResetValue ();
		offsetCapsuleColliser = new Vector2 (0, -1.13f);
	}
	void OnTriggerStay2D(Collider2D col){
		if (col.transform.parent.tag != "Enemy")
			return;
		if (timer < timeDelayAttack)
			return;
		Send (col.transform.parent);
		timer = 0;
	}
}
