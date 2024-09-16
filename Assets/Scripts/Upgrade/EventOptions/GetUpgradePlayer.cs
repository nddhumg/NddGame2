using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GetUpgradePlayer : NddBehaviour	{
	[SerializeField] protected AbilityPlayerCtrl abilityPlayerCtrl;
	[SerializeField] protected UnlockAbilityPlayer unlockAbilityPlayer;
	[SerializeField] protected Dictionary<UpgradeCode,AbilityCustomizableObject> dictionaryCustomizableObject = new Dictionary<UpgradeCode,AbilityCustomizableObject>();

	protected override void Start(){
		UpgradeManager.Instance.OnUpgradeStat += OnSelectionEnhancementStats;
		UpgradeManager.Instance.OnUpgradeAbility += OnSelectionEnhancementAbility;
		AddCustomizableObject ();
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
	protected void AddCustomizableObject(){
		dictionaryCustomizableObject.Add (UpgradeCode.BoostDamage,new AbilityDamageCustomization(PlayerCtrl.Instance.AttributesPlayer));
		dictionaryCustomizableObject.Add (UpgradeCode.BoostHp,new AbilityHpMaxCustomization(PlayerCtrl.Instance.DamageReceiver));
		dictionaryCustomizableObject.Add (UpgradeCode.BoostRangePickUp,new AbilityRangePickUpCustomization(PlayerCtrl.Instance.PickUp));
		dictionaryCustomizableObject.Add (UpgradeCode.BoostSpeed,new AbilitySpeedCustomization(PlayerCtrl.Instance.MovingPlayer));
		dictionaryCustomizableObject.Add (UpgradeCode.BoostSpeedAttack,new AbilityShootingRateCustomization(PlayerCtrl.Instance.ShotPlayer));
	}
	protected void OnSelectionEnhancementStats(UpgradeStatSO select){
		AbilityCustomizableObject custom = dictionaryCustomizableObject [select.nameCard];
		custom.ParamemterCustomization (select.attribute, true);

	} 
	protected void OnSelectionEnhancementStats(UpgradeCode select){
		if (!IsSelectionParameters (select))
			return;
		string resPath = "ScriptableObject/Enhancement/" +	select.ToString();;
		UpgradeStatSO UpgradeCard = Resources.Load<UpgradeStatSO> (resPath);
		if (UpgradeCard == null) {
			Debug.LogError("Dont resources load: "+ resPath );
			return;
		}
		AbilityCustomizableObject custom = dictionaryCustomizableObject [select];
		custom.ParamemterCustomization (UpgradeCard.attribute, true);

	} 
	protected void OnSelectionEnhancementAbility(UpgradeCode select){
		if (!IsSelectionAbility (select))
			return;
		Transform ability = unlockAbilityPlayer.UnlockAbility (select.ToString ());
		if(ability == null){
			Transform abilityTF = unlockAbilityPlayer.GetAbilityUnLock(select.ToString());
			LevelAbility level = abilityTF.GetComponentInChildren<LevelAbility> ();
			level?.LevelAbilityUp();
		}
	}
	private bool IsSelectionParameters(UpgradeCode select){
		return (int)select < 100;
	}
	private bool IsSelectionAbility(UpgradeCode select){
		return (int)select  >= 100;
	}
}
