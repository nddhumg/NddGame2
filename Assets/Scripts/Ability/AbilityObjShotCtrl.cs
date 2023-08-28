using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityObjShotCtrl : AbilityCtrl {
	[SerializeField] protected AbilityShot abilityShot;
	public AbilityShot AbilityShot{
		get{
			return abilityShot;
		}
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadAbilityShot ();
	}
	protected virtual void LoadAbilityShot(){
		if (this.abilityShot != null)
			return;
		this.abilityShot = GetComponentInChildren<AbilityShot> ();
		Debug.LogWarning ("Add AbilityShot", gameObject);
	}
}
