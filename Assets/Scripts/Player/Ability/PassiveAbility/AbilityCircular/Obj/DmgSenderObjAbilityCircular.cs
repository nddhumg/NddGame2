using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DmgSenderObjAbilityCircular : DamageSender {
	[SerializeField]protected AbilityCircularPlayer abilityCircularPlayer;
	[SerializeField] protected Vector2 offsetCapsule = new Vector2(0f, 0f);
	[SerializeField] protected Vector2 sizeCapsule = new Vector2(0.56f, 0.9f);


	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadAbilityCircular ();
	}
	void FixedUpdate(){
		damage = abilityCircularPlayer.Damage;
	}
	protected override void SetCapsuleCollider2D(){
		capsuleCollider2D.offset = offsetCapsule;
		capsuleCollider2D.size = sizeCapsule;
	}
	protected virtual void LoadAbilityCircular(){
		if (this.abilityCircularPlayer != null)
			return;
		this.abilityCircularPlayer= transform.GetComponentInParent<AbilityCircularPlayer>();
		Debug.LogWarning ("Add AbilityCircular", gameObject);
	}
	void OnTriggerEnter2D(Collider2D col){
		Send (col.transform.parent);
	}
}
