using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class AbilityShootingRateCustomization : AbilityCustomizeShooting {
	
	protected override void GetParameter(){
		parameter = this.abilityShot.DelayAbility;
	}
	protected override void SetParameter ()
	{
		abilityShot.SetDelayShot (parameterCompleted);
	}
	protected override void ParameterIcrease(float fireRateModified){
		parameterCompleted = parameter - fireRateModified;
	}
	protected override void ParameterDecrease(float fireRateModified){
		parameterCompleted = parameter + fireRateModified;
	}
}
