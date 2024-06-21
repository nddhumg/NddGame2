using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHpMaxCustomization : AbilityCustomizableObject {
	protected DamageReceiver damageReceiver;
	public AbilityHpMaxCustomization(DamageReceiver damageReceiver){
		this.damageReceiver = damageReceiver;
	}
	protected override void GetParameter(){
		this.parameter = damageReceiver.HpMax;
	}
	protected override void ParameterIcrease (float hpMaxModified){
		this.parameterCompleted = parameter + hpMaxModified;
	}
	protected override void ParameterDecrease(float hpMaxModified){
		this.parameterCompleted = parameter - hpMaxModified;
	}
	protected override void SetParameter (){
		damageReceiver.SetHpMax(this.parameterCompleted);
	}
}
