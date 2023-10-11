using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class DamageSenderEnemy : DamageSender {
	[SerializeField] protected float timer =1f;
	[SerializeField] protected float timeDelayAttack = 1f;

	protected override void ResetValueComponent ()
	{
		base.ResetValueComponent ();
		SetDamageWhenReset ();
	}
	protected virtual void FixedUpdate(){
		if(timer <=  timeDelayAttack)
		timer += Time.fixedDeltaTime;
	}

	protected abstract void SetDamageWhenReset ();
	protected override void Send (DamageReceiver receiver)
	{
		if (timer < timeDelayAttack)
			return;
		base.Send (receiver);
		timer = 0;
	}
	protected virtual void OnTriggerStay2D(Collider2D col){
		if (col.isTrigger)
			return;
		if (col.transform.parent.CompareTag ("Enemy"))
			return;
		Send (col.transform.parent);
	}
}
