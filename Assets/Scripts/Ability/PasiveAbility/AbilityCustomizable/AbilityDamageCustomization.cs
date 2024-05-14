using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDamageCustomization : AbilityCustomizableObject {
	[SerializeField] protected AttributesPlayer attributesPlayer;

	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadAttributesPlayer ();
	}
	protected virtual void LoadAttributesPlayer(){
		if (this.attributesPlayer != null)
			return;
		this.attributesPlayer = transform.root.GetComponentInChildren<AttributesPlayer>();
		Debug.LogWarning ("Add AttributesPlayer", gameObject);
	}
	protected override void GetParameter(){
		this.parameter = attributesPlayer.Damage;
	}
	protected override void ParameterIcrease (float damageModified){
		this.parameterCompleted = parameter + damageModified;
	}
	protected override void ParameterDecrease(float damageModified){
		this.parameterCompleted = parameter - damageModified;
	}
	protected override void SetParameter (){
		attributesPlayer.SetDamage(this.parameterCompleted);
	}
}
