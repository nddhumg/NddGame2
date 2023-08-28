using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHpMaxCustomization : AbilityCustomizableObject {
	[SerializeField] protected DamageReceiver damageReceiver;

	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadDamageReceiver ();
	}
	protected virtual void LoadDamageReceiver(){
		if (this.damageReceiver != null)
			return;
		this.damageReceiver = transform.parent.parent.parent.GetComponentInChildren<DamageReceiver>();
		Debug.LogWarning ("Add DamageReceiver", gameObject);
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
