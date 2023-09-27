using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DmgSenderObjAbilityCircular : DamageSender,ISetDamagePlayer {
	[SerializeField]protected AbilityCircular abilityCircular;
	[SerializeField] protected Vector2 offsetCapsule = new Vector2(0f, 0f);
	[SerializeField] protected Vector2 sizeCapsule = new Vector2(0.56f, 0.9f);


	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadAbilityCircular ();
	}
	void OnEnable(){
		PlayerCtrl playerCtrl = abilityCircular.Ability.ObjectCtrl as PlayerCtrl;
		playerCtrl.AttributesPlayer.AddObsever (this);
	}
	protected override void ResetValueComponent ()
	{
		base.ResetValueComponent ();
		PlayerCtrl playerCtrl = abilityCircular.Ability.ObjectCtrl as PlayerCtrl;
		damage = playerCtrl.AttributesPlayer.Damage;
	}
	protected override void SetCapsuleCollider2D(){
		capsuleCollider2D.offset = offsetCapsule;
		capsuleCollider2D.size = sizeCapsule;
	}
	protected virtual void LoadAbilityCircular(){
		if (this.abilityCircular != null)
			return;
		this.abilityCircular= transform.GetComponentInParent<AbilityCircular>();
		Debug.LogWarning ("Add AbilityCircular", gameObject);
	}
	public void OnSetDamage(float damage){
		this.damage = damage;
	}
	void OnTriggerEnter2D(Collider2D col){
		Send (col.transform.parent);
	}
}
