using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCircularPlayer : AbilityCircular  {
	[Header("Player Ability")]
	[SerializeField] protected AbilityCircularPlayerCtrl ctrl;
	protected override void Start ()
	{
		base.Start ();
		ctrl.LevelAbility.LevelAbilityUp ();
	}


	public virtual void SetDamageObj(){
		foreach (Transform child in holder) {
			DamageSender damageSender = child.GetComponentInChildren<DamageSender> ();
			damageSender.SetDamage (ctrl.DamagePlayerAbility.Damage);
		}
	}

	public override GameObject InstantiatePrab ()
	{
		GameObject obj =  base.InstantiatePrab ();
		SetDamageObj ();
		return obj;
	}
	protected override void ResetValue ()
	{
		base.ResetValue ();
		speed = 1f;
		maxPrefab = 6;
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadAbilityCircularPlayerCtrl ();
	}
	protected override void LoadCenterPositionCircular ()
	{
		if (centerPosition != null)
			return;
		centerPosition = transform;
		Debug.LogWarning ("Add centerPosition", gameObject);
	}
	protected virtual void LoadAbilityCircularPlayerCtrl(){
		if (ctrl != null)
			return;
		ctrl = transform.GetComponent<AbilityCircularPlayerCtrl>();
		Debug.LogWarning ("Add AbilityCircularPlayerCtrl", gameObject);
	}
}
