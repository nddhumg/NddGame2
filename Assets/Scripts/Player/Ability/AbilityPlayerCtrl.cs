using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPlayerCtrl : AbilityObjShotCtrl {
	[SerializeField] protected AbilityShootingRateCustomization abilityFireRateCustomization;
	[SerializeField] protected AbilityShootingDamageCustomization abilityFireDamageCustomization;
	[SerializeField] protected AbilityHpMaxCustomization abilityHpMaxCustomization;
	[SerializeField] protected AbilitySpeedCustomization abilitySpeedCustomization;
	[SerializeField] protected AbilityRangePickUpCustomization abilityRangePickUpCustomization;

	public AbilityHpMaxCustomization AbilityHpMaxCustomization{
		get{
			return abilityHpMaxCustomization;
		}
	}
	public AbilityRangePickUpCustomization AbilityRangePickUpCustomization{
		get{
			return abilityRangePickUpCustomization;
		}
	}
	public AbilitySpeedCustomization AbilitySpeedCustomization{
		get{
			return abilitySpeedCustomization;
		}
	}
	public AbilityShootingRateCustomization AbilityFireRateCustomization{
		get{
			return abilityFireRateCustomization;
		}
	}
	public AbilityShootingDamageCustomization AbilityFireDamageCustomization{
		get{
			return abilityFireDamageCustomization;
		}
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadAbilityFireRateCustomization ();
		this.LoadAbilityFireDamageCustomization ();
		this.LoadAbilitySpeedCustomization ();
		this.LoadAbilityHpMaxCustomization ();
		this.LoadAbilityRangePickUpCustomization ();
	}
	protected virtual void LoadAbilityRangePickUpCustomization(){
		if (this.abilityRangePickUpCustomization != null)
			return;
		this.abilityRangePickUpCustomization = GetComponentInChildren<AbilityRangePickUpCustomization> ();
		Debug.LogWarning ("Add AbilityRangePickUpCustomization", gameObject);
	}
	protected virtual void LoadAbilityHpMaxCustomization(){
		if (this.abilityHpMaxCustomization != null)
			return;
		this.abilityHpMaxCustomization = GetComponentInChildren<AbilityHpMaxCustomization> ();
		Debug.LogWarning ("Add AbilityHpMaxCustomization", gameObject);
	}
	protected virtual void LoadAbilitySpeedCustomization(){
		if (this.abilitySpeedCustomization != null)
			return;
		this.abilitySpeedCustomization = GetComponentInChildren<AbilitySpeedCustomization> ();
		Debug.LogWarning ("Add AbilitySpeedCustomization", gameObject);
	}
	protected virtual void LoadAbilityFireRateCustomization(){
		if (this.abilityFireRateCustomization != null)
			return;
		this.abilityFireRateCustomization = GetComponentInChildren<AbilityShootingRateCustomization> ();
		Debug.LogWarning ("Add AbilityFireRateCustomization", gameObject);
	}
	protected virtual void LoadAbilityFireDamageCustomization(){
		if (this.abilityFireDamageCustomization != null)
			return;
		this.abilityFireDamageCustomization = GetComponentInChildren<AbilityShootingDamageCustomization> ();
		Debug.LogWarning ("Add LoadAbilityFireDamageCustomization", gameObject);
	}
}
