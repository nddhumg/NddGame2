using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPlayerWaterTornado : AbilityCreateObjAround {
	[SerializeField] protected AbilityPlayerWaterTornadoCtrl ctrl;

	protected override void Start ()
	{
		base.Start ();
		ctrl.LevelAbility.LevelAbilityUp ();
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadAbilityPlayerWaterTornadoCtrl ();
	}
	protected virtual void LoadAbilityPlayerWaterTornadoCtrl(){
		if (ctrl != null)
			return;
		ctrl = transform.GetComponent<AbilityPlayerWaterTornadoCtrl>();
		Debug.LogWarning ("Add AbilityPlayerWaterTornadoCtrl", gameObject);
	}
	protected override void ResetValue ()
	{
		timeSpawn = 7f;
		positionSpawnMax = new Vector2 (5f, 5f);
	}
	protected override GameObject CreateObj (Vector3 position, Quaternion rotation){
		Transform WaterTornadoObj = ObjSkillSpawner.Instance.Spawn (GetObjSkillName(), position, rotation);
		WaterTornadoObj.GetComponentInChildren<DamageSender> ().SetDamage(ctrl.DamagePlayerAbility.Damage);
		return WaterTornadoObj.gameObject ;
	}
	protected virtual string GetObjSkillName(){
		return ObjSkillSpawner.ObjSkillName.WaterTornado.ToString();
	}
}
