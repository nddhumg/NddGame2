using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityCustomizableObject  {
 	protected float parameter;
 	protected float parameterCompleted;

	protected abstract void GetParameter ();
	protected abstract void ParameterIcrease (float parameterModified);
	protected abstract void ParameterDecrease(float parameterModified);
	protected abstract void SetParameter();
	public virtual void ParamemterCustomization(float parameterModified , bool adjustment){
		this.GetParameter ();
		if (adjustment) {
			ParameterIcrease (parameterModified);
		} 
		else{
			ParameterDecrease (parameterModified);
		}
		this.SetParameter();
	}
}
