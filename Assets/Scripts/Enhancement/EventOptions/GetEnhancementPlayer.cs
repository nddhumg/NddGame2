﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEnhancementPlayer : NddBehaviour,IEvenetEnhancementSelection{
	[SerializeField] protected AbilityPlayerCtrl abilityPlayerCtrl;
	[SerializeField] protected UnlockAbilityPlayer unlockAbilityPlayer;

	protected virtual void OnEnable(){
		EnhancementOptions.Instance.AddObsever (this);
	}
	protected virtual void OnDisable(){
		EnhancementOptions.Instance.RemoveObsever (this);
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadAbilityPlayerCtrl ();
	}
	protected virtual void LoadAbilityPlayerCtrl(){
		if (this.abilityPlayerCtrl != null)
			return;
		this.abilityPlayerCtrl= transform.parent.GetComponentInChildren<AbilityPlayerCtrl>();;
		Debug.LogWarning ("Add AbilityPlayerCtrl", gameObject);
	}
	public void OnSelectionEnhancement(EnhancementCode select){
			OnSelectionEnhancementAbility(select);
			OnSelectionEnhancementParameters(select);
	}
	protected void OnSelectionEnhancementParameters(EnhancementCode select){
		if (!IsSelectionParameters (select))
			return;
		string resPath = "ScriptableObject/Enhancement/" +	select.ToString();;
		EnhancementCardSO enhancementCard = Resources.Load<EnhancementCardSO> (resPath);
		if (enhancementCard == null) {
			Debug.LogError("Dont resources load: "+ resPath );
			return;
		}
		switch (select) 
		{
		case EnhancementCode.BoostHp:
			abilityPlayerCtrl.AbilityHpMaxCustomization.ParamemterCustomization(enhancementCard.attribute,true);
			break;

		case EnhancementCode.BoostSpeed:
			abilityPlayerCtrl.AbilitySpeedCustomization.ParamemterCustomization(enhancementCard.attribute,true);
			break;

		case EnhancementCode.BoostSpeedAttack:
			abilityPlayerCtrl.AbilityFireRateCustomization.ParamemterCustomization(enhancementCard.attribute,true);
			break;

		case EnhancementCode.BoostDamage:
			abilityPlayerCtrl.AbilityDamageCustomization.ParamemterCustomization(enhancementCard.attribute,true);
			break;

		case EnhancementCode.BoostRangePickUp:
			abilityPlayerCtrl.AbilityRangePickUpCustomization.ParamemterCustomization(enhancementCard.attribute,true);
			break;
		default:
			Debug.LogWarning("Dont event select Parameters "+select.ToString(),gameObject);
			break;
		}
	} 
	protected void OnSelectionEnhancementAbility(EnhancementCode select){
		if (!IsSelectionAbility (select))
			return;
		UnlockAbilityPlayer.NameAbilityLock nameAbility = unlockAbilityPlayer.SwithFormEnhancementCodetoNameAbilityUnlock(select);
		if (nameAbility == UnlockAbilityPlayer.NameAbilityLock.NoAbility) {
			Debug.LogWarning("Dont event select Ability " + select.ToString(),gameObject);
			return;
		}
		if(!unlockAbilityPlayer.IsAbilityUnlocked(nameAbility))
			unlockAbilityPlayer.UnlockAbility(nameAbility);
		else{
			Transform abilityTF = unlockAbilityPlayer.GetTfByKeyListAbilityTf (nameAbility.ToString ());
			LevelAbility level = abilityTF?.GetComponentInChildren<LevelAbility> ();
			level.LevelAbilityUp();
		}
	}
	private bool IsSelectionParameters(EnhancementCode select){
		return (int)select < 100;
	}
	private bool IsSelectionAbility(EnhancementCode select){
		return (int)select  >= 100;
	}
}
