using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUpgradePlayer : NddBehaviour,IEvenetUpgradeSelect{
	[SerializeField] protected AbilityPlayerCtrl abilityPlayerCtrl;
	[SerializeField] protected UnlockAbilityPlayer unlockAbilityPlayer;

	protected override void Start(){
		UpgradeManager.Instance.AddObsever (this);
	}
	protected virtual void OnDisable(){
		UpgradeManager.Instance.RemoveObsever (this);
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
	public void OnSelectionEnhancement(UpgradeCode select){
			OnSelectionEnhancementAbility(select);
			OnSelectionEnhancementParameters(select);
	}
	protected void OnSelectionEnhancementParameters(UpgradeCode select){
		if (!IsSelectionParameters (select))
			return;
		string resPath = "ScriptableObject/Enhancement/" +	select.ToString();;
		UpgradeCardSO enhancementCard = Resources.Load<UpgradeCardSO> (resPath);
		if (enhancementCard == null) {
			Debug.LogError("Dont resources load: "+ resPath );
			return;
		}
		switch (select) 
		{
		case UpgradeCode.BoostHp:
			abilityPlayerCtrl.PassiveAbilityPlayerCtrl.AbilityHpMaxCustomization.ParamemterCustomization(enhancementCard.attribute,true);
			break;

		case UpgradeCode.BoostSpeed:
			abilityPlayerCtrl.PassiveAbilityPlayerCtrl.AbilitySpeedCustomization.ParamemterCustomization(enhancementCard.attribute,true);
			break;

		case UpgradeCode.BoostSpeedAttack:
			abilityPlayerCtrl.PassiveAbilityPlayerCtrl.AbilityFireRateCustomization.ParamemterCustomization(enhancementCard.attribute,true);
			break;

		case UpgradeCode.BoostDamage:
			abilityPlayerCtrl.PassiveAbilityPlayerCtrl.AbilityDamageCustomization.ParamemterCustomization(enhancementCard.attribute,true);
			break;

		case UpgradeCode.BoostRangePickUp:
			abilityPlayerCtrl.PassiveAbilityPlayerCtrl.AbilityRangePickUpCustomization.ParamemterCustomization(enhancementCard.attribute,true);
			break;
		default:
			Debug.LogWarning("Dont event select Parameters "+select.ToString(),gameObject);
			break;
		}
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
