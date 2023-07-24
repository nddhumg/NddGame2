using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public abstract class DamageReceiver : NddBehaviour {
	[SerializeField] protected float hp = 0f;
	[SerializeField] protected float hpMax = 2f;
	[SerializeField] protected bool isDead = false;

	protected override void Start ()
	{
		base.Start ();
		this.ResetHp ();
	}
	void FixedUpdate(){
		this.IsDead ();
		if(this.isDead)
		this.OnDead ();
	}
	protected virtual void IsDead(){
		if (this.hp <= 0)
			this.isDead = true;
		else
			this.isDead = false;
	}
	protected abstract void OnDead ();
	public virtual void ResetHp() {
		this.hp = this.hpMax;
	}
	public virtual void AddHp(float addHp) {
		this.hp += addHp;
		if (this.hp >= hpMax) {
			this.hp = this.hpMax;
		}
	}
	public virtual void Receiver(float damage) {
		this.hp -= damage;
		if (this.hp <= 0) {
			this.hp = 0;
		} 
	}
}
