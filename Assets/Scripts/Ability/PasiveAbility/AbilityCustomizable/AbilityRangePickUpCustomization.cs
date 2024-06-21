using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityRangePickUpCustomization : AbilityCustomizableObject {
	 protected PickUp pickUp;
	public AbilityRangePickUpCustomization(PickUp pickUp){
		this.pickUp = pickUp;
	}
	protected override void GetParameter(){
		this.parameter = pickUp.CurrentRangePickUp;
	}
	protected override void ParameterIcrease (float rangePickUpModified){
		this.parameterCompleted = parameter + rangePickUpModified;
	}
	protected override void ParameterDecrease(float rangePickUpModified){
		this.parameterCompleted = parameter - rangePickUpModified;
	}
	protected override void SetParameter (){
		pickUp.SetRangePickUp(this.parameterCompleted);
	}
}