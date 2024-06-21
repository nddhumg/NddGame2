using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDamageCustomization : AbilityCustomizableObject {
	protected AttributesPlayer attributesPlayer;
	public AbilityDamageCustomization(AttributesPlayer attributesPlayer){
		this.attributesPlayer = attributesPlayer;
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
