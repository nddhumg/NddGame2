using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAbilityPlayerWaterTornado : LevelAbility {
	[SerializeField] protected AbilityPlayerWaterTornadoCtrl abilityPlayerWaterTornadoCtrl;

	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadAbilityPlayerWaterTornadoCtrl ();
	}
	protected virtual void LoadAbilityPlayerWaterTornadoCtrl(){
		if (abilityPlayerWaterTornadoCtrl != null)
			return;
		abilityPlayerWaterTornadoCtrl = transform.parent.GetComponent<AbilityPlayerWaterTornadoCtrl> ();
		Debug.LogWarning ("Add AbilityPlayerWaterTornadoCtrl", gameObject);
	}
	public override void LevelAbilityUp(){
		int nextLevel = (int)levelCurrent+1;
		switch (nextLevel) 
		{
		case 1:
			abilityPlayerWaterTornadoCtrl.AbilityPlayerWaterTornado.QuantityObj = 1;
			break;
		case 2:
			abilityPlayerWaterTornadoCtrl.DamagePlayerAbility.SetDamageRatio (2f);
			break;
		case 3:
			abilityPlayerWaterTornadoCtrl.AbilityPlayerWaterTornado.QuantityObj = 2;
			abilityPlayerWaterTornadoCtrl.DamagePlayerAbility.SetDamageRatio (3f);
			abilityPlayerWaterTornadoCtrl.AbilityPlayerWaterTornado.TimeSpawn -=  1f;
			break;
		case 4:
			abilityPlayerWaterTornadoCtrl.DamagePlayerAbility.SetDamageRatio (5f);
			abilityPlayerWaterTornadoCtrl.AbilityPlayerWaterTornado.TimeSpawn -=  1f;
			break;
		case 5:
			abilityPlayerWaterTornadoCtrl.AbilityPlayerWaterTornado.QuantityObj = 3;
			abilityPlayerWaterTornadoCtrl.DamagePlayerAbility.SetDamageRatio (8f);
			break;
		default:
			return;
		}
		LevelUp ();
	}
}
