using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityRangePickUpCustomization : AbilityCustomizableObject {
	[SerializeField] protected PickUpItem pickUpItem;

	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadPickUpItem ();
	}
	protected virtual void LoadPickUpItem(){
		if (this.pickUpItem != null)
			return;
		this.pickUpItem = transform.parent.parent.parent.GetComponentInChildren<PickUpItem>();
		Debug.LogWarning ("Add PickUpItem", gameObject);
	}
	protected override void GetParameter(){
		this.parameter = pickUpItem.CurrentRangePickUp;
	}
	protected override void ParameterIcrease (float rangePickUpModified){
		this.parameterCompleted = parameter + rangePickUpModified;
	}
	protected override void ParameterDecrease(float rangePickUpModified){
		this.parameterCompleted = parameter - rangePickUpModified;
	}
	protected override void SetParameter (){
		pickUpItem.SetRangePickUp(this.parameterCompleted);
	}
}