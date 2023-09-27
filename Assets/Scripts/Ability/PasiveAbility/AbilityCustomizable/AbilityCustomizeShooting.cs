using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityCustomizeShooting : AbilityCustomizableObject {
	[Header("Ability Shooting Customization")]
	[SerializeField] protected AbilityShot abilityShot;

	protected virtual void LoadAbilityShot(){
		if (this.abilityShot != null)
			return;
		this.abilityShot = transform.parent.parent.GetComponentInChildren<AbilityShot>();
		Debug.LogWarning ("Add AbilityShot", gameObject);
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadAbilityShot ();
	}


}
