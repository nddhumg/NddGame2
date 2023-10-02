using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEnhancementPlayer : GetEnhancement{
	[Header("Get Enhancement Player")]
	[SerializeField] protected AbilityPlayerCtrl abilityPlayerCtrl;
	[SerializeField] protected UnlockAbilityPlayer unlockAbilityPlayer;
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadAbilityPlayerCtrl ();
	}
	protected virtual void LoadAbilityPlayerCtrl(){
		if (this.abilityPlayerCtrl != null)
			return;
		this.abilityPlayerCtrl= this.abilityCtrl as AbilityPlayerCtrl;
		Debug.LogWarning ("Add AbilityPlayerCtrl", gameObject);
	}
	public override void OnSelectionEnhancement(EnhancementCode select){
		try{
			string resPath = "ScriptableObject/Enhancement/" +	select.ToString();;
			EnhancementCardSO enhancementCard = Resources.Load<EnhancementCardSO> (resPath);

			EnhancementCode EventSelect = select;
			switch (EventSelect) 
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
			case EnhancementCode.AbilityCircular:
				UnlockAbilityPlayer.NameAbilityUnlock nameAbility = unlockAbilityPlayer.SwithFormEnhancementCodetoNameAbilityUnlock(EnhancementCode.AbilityCircular);
				if(!unlockAbilityPlayer.IsAbilityUnlocked(nameAbility))
					unlockAbilityPlayer.UnlockAbility(nameAbility);
				else{
					unlockAbilityPlayer.GetTfByKeyListAbilityTf(nameAbility.ToString())?.GetComponentInChildren<LevelAbility>().LevelAbilityUp();
				}
				break;
				
			default:
				Debug.LogWarning("Dont event select "+EventSelect.ToString(),gameObject);
				break;
			}
		}
		catch
		{
			Debug.LogError("Error OnSelectionEnhancement in Player",gameObject);
		}
	}

}
