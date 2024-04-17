using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPlayerWaterTornadoCtrl : AbilityUnlockCtrl {
	[SerializeField] protected AbilityPlayerWaterTornado abilityPlayerWaterTornado;
	public AbilityPlayerWaterTornado AbilityPlayerWaterTornado{
		get{ 
			return abilityPlayerWaterTornado;
			}
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadAbilityPlayerWaterTornado();
	}
	protected virtual void LoadAbilityPlayerWaterTornado(){
		if (this.abilityPlayerWaterTornado != null)
			return;
		this.abilityPlayerWaterTornado= GetComponent<AbilityPlayerWaterTornado>();
		Debug.LogWarning ("Add AbilityPlayerWaterTornado", gameObject);
	}
}
