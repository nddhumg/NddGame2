using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPlayerWaterTornado : AbilityCreateObjAround {
	[SerializeField] protected AbilityPlayerWaterTornadoCtrl abilityPlayerWaterTornadoCtrl;

	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadAbilityPlayerWaterTornadoCtrl ();
	}
	protected virtual void LoadAbilityPlayerWaterTornadoCtrl(){
		if (abilityPlayerWaterTornadoCtrl != null)
			return;
		abilityPlayerWaterTornadoCtrl = transform.GetComponent<AbilityPlayerWaterTornadoCtrl>();
		Debug.LogWarning ("Add AbilityPlayerWaterTornadoCtrl", gameObject);
	}
	protected override void ResetValue ()
	{
		timeSpawn = 7f;
		positionSpawnMax = new Vector2 (5f, 5f);
	}
	protected override GameObject CreateObj (Vector3 position, Quaternion rotation){
		Transform WaterTornadoObj = SpawnFx.Instance.Spawn (GetFxSkillName(), position, rotation);
		WaterTornadoObj.GetComponentInChildren<DamageSender> ().SetDamage(abilityPlayerWaterTornadoCtrl.DamagePlayerAbility.Damage);
		return WaterTornadoObj.gameObject ;
	}
	protected virtual string GetFxSkillName(){
		return FxName.WaterTornado.ToString ();
	}
}
