using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityRangePickUpCustomization : AbilityCustomizableObject {
	[SerializeField] protected PickUp pickUp;

	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadPickUpItem ();
	}
	protected virtual void LoadPickUpItem(){
		if (this.pickUp != null)
			return;
		this.pickUp = transform.parent.parent.parent.GetComponentInChildren<PickUp>();
		Debug.LogWarning ("Add PickUpItem", gameObject);
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