using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityShootingDamageCustomization : AbilityCustomizeShooting {
	protected override void GetParameter(){
		this.parameter = abilityShot.Damage;
	}
	protected override void ParameterIcrease (float fireDamageModified){
		this.parameterCompleted = parameter + fireDamageModified;
	}
	protected override void ParameterDecrease(float fireDamageModified){
		this.parameterCompleted = parameter - fireDamageModified;
	}
	protected override void SetParameter (){
		abilityShot.SetDamage (this.parameterCompleted);
	}
}
