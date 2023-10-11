using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DmgSenderObjAbilityCircular : DamageSender {
	[SerializeField]protected AbilityCircularPlayerCtrl abilityCircularPlayerCtrl;
	protected override void ResetValue ()
	{
		base.ResetValue ();
		offsetCapsuleColliser = new Vector2(0f, 0f);
		sizeCapsuleColliser = new Vector2(0.56f, 0.9f);
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadAbilityCircularPlayerCtrl ();
	}
	void FixedUpdate(){
		damage = abilityCircularPlayerCtrl.DamagePlayerAbility.Damage;
	}
	protected virtual void LoadAbilityCircularPlayerCtrl(){
		if (this.abilityCircularPlayerCtrl != null)
			return;
		this.abilityCircularPlayerCtrl= transform.parent.parent.parent.GetComponent<AbilityCircularPlayerCtrl>();
		Debug.LogWarning ("Add AbilityCircularPlayerCtrl", gameObject);
	}
	void OnTriggerEnter2D(Collider2D col){
		Send (col.transform.parent);
	}
}
