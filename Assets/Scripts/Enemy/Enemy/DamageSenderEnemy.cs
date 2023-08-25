using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
public abstract class DamageSenderEnemy : DamageSender {
	[SerializeField] protected CircleCollider2D circleCollider2D;
	[SerializeField] protected float timer =1f;
	[SerializeField] protected float timeDelayAttack = 1f;
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadCircleCollider2D();
	}
	protected override void ResetValue ()
	{
		base.ResetValue ();
		SetDamageWhenReset ();
	}
	protected virtual void FixedUpdate(){
		timer += Time.fixedDeltaTime;
	}
	protected virtual void LoadCircleCollider2D(){
		if (this.circleCollider2D != null)
			return;
		this.circleCollider2D= GetComponent<CircleCollider2D>();
		SetCircleCollider2D ();
		circleCollider2D.isTrigger = true;
		Debug.LogWarning ("Add CircleCollider2D", gameObject);
	}
	protected  abstract void SetCircleCollider2D ();
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
