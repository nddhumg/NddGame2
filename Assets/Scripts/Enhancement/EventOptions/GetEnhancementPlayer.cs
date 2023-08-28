using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEnhancementPlayer : GetEnhancement{
	[Header("Get Enhancement Player")]
	[SerializeField] protected AbilityPlayerCtrl abilityPlayerCtrl;
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
				EventBoostHpMax (enhancementCard.attribute);
				break;
			case EnhancementCode.BoostSpeed:
				EventBoostSpeed (enhancementCard.attribute);
				break;
			case EnhancementCode.BoostSpeedAttack:
				EventBoostSpeedAttack(enhancementCard.attribute);
				break;
			case EnhancementCode.BoostDamage:
				EventBoostDamageAttack(enhancementCard.attribute);
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

	protected virtual void EventBoostHpMax(float hpBoost){
		abilityPlayerCtrl.AbilityHpMaxCustomization.ParamemterCustomization(hpBoost,true);
	}
	protected virtual void EventBoostSpeed(float speedUp){
		abilityPlayerCtrl.AbilitySpeedCustomization.ParamemterCustomization(speedUp,true);
	}
	protected virtual void EventBoostSpeedAttack(float speedAttackUp){
		abilityPlayerCtrl.AbilityFireRateCustomization.ParamemterCustomization(speedAttackUp,true);
	}
	protected virtual void EventBoostDamageAttack(float damageAttackUp){
		abilityPlayerCtrl.AbilityFireDamageCustomization.ParamemterCustomization(damageAttackUp,true);
	}
}
