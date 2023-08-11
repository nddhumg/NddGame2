using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhancementPlayer : NddBehaviour,IEvenetEnhancementSelection {
	[SerializeField] protected EnhancementOptions enhancementOptions;
	[SerializeField] protected PlayerCtrl playerCtrl;
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadEnhancementOptions ();
		this.LoadPlayerCtrl ();
	}
	protected virtual void LoadEnhancementOptions(){
		if (this.enhancementOptions != null)
			return;
		this.enhancementOptions= GameObject.Find("EnhancementOptions").GetComponent<EnhancementOptions>();
		Debug.LogWarning ("Add EnhancementOptions", gameObject);
	}
	protected virtual void LoadPlayerCtrl(){
		if (this.playerCtrl != null)
			return;
		this.playerCtrl= transform.parent.GetComponent<PlayerCtrl>();
		Debug.LogWarning ("Add PlayerCtrl", gameObject);
	}

	protected virtual void OnEnable(){
		enhancementOptions.AddObsever (this);
	}
	protected virtual void OnDisable(){
		enhancementOptions.RemoveObsever (this);
	}
	public void OnSelectionEnhancement(EnhancementCode select){
		try{
			string resPath = "ScriptableObject/Enhancement/" +	select.ToString();;
			EnhancementCardSO enhancementCard = Resources.Load<EnhancementCardSO> (resPath);

			EnhancementCode EventSelect = select;
			switch (EventSelect) 
			{
			case EnhancementCode.BoostHp:
				EventBoostHp (enhancementCard.attribute);
				break;
			case EnhancementCode.BoostSpeed:
				EventBoostSpeed (enhancementCard.attribute);
				break;
			case EnhancementCode.BoostSpeedAttack:
				EventBoostSpeedAttack(enhancementCard.attribute);
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

	protected virtual void EventBoostHp(float hpBoost){
		playerCtrl.DamageReceiver.AddHpMaxAndHp(hpBoost);
	}
	protected virtual void EventBoostSpeed(float speedUp){
		playerCtrl.MovingPlayer.SpeedUp (speedUp);
	}
	protected virtual void EventBoostSpeedAttack(float speedAttackUp){
		playerCtrl.ShotPlayer.BoostAttackSpeed (speedAttackUp);
	}
}
