using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbillityHolySwordPlayerManager : AbilityCreatePrefab {
	[SerializeField] protected List<HolySwordCtrl> listObjCtrl = new List<HolySwordCtrl>();
	[SerializeField] protected AbilityHolySwordPlayerCtrl ctrl;

	public override GameObject InstantiatePrab ()
	{
		GameObject newPrefab =  base.InstantiatePrab ();
		listObjCtrl.Add(newPrefab.GetComponent<HolySwordCtrl>());
//		newPrefab.GetComponentInChildren<DamageSender> ().SetDamage(ctrl);

		return newPrefab;
	}

	public void SetSpeedObj(float speed){
		foreach (HolySwordCtrl ctrl in listObjCtrl) {
			ctrl.HolySwordMove.Speed = speed;
		}
	}
	public void SetDamageObj(float damage){
		foreach (HolySwordCtrl ctrl in listObjCtrl) {
			ctrl.DmgSenderHolySword.SetDamage(damage);
		}
	}
	public void IncreaseSpeedObj(float value){
		foreach (HolySwordCtrl ctrl in listObjCtrl) {
			ctrl.HolySwordMove.IncreaseSpeed(value);
		}
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadAbilityHolySwordPlayerCtrl ();
	}
	protected virtual void LoadAbilityHolySwordPlayerCtrl(){
		if (ctrl != null)
			return;
		ctrl = transform.GetComponent<AbilityHolySwordPlayerCtrl> ();
		Debug.LogWarning ("Add AbilityHolySwordPlayerCtrl", gameObject);
	}
}
