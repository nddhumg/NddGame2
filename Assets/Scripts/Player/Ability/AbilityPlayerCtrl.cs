using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPlayerCtrl : NddBehaviour {
	[SerializeField] protected PassiveAbilityPlayerCtrl passiveAbilityPlayerCtrl;
	[SerializeField] protected UnlockAbilityPlayer abilityUnlock;
	public UnlockAbilityPlayer AbilityUnlock{
		get{
			return abilityUnlock;
		}
	}
	public PassiveAbilityPlayerCtrl PassiveAbilityPlayerCtrl{
		get{
			return passiveAbilityPlayerCtrl;
		}
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadUnlockAbilityPlayer ();
		LoadPassiveAbilityPlayerCtrl ();
	}
	protected virtual void LoadUnlockAbilityPlayer(){
		if (this.abilityUnlock != null)
			return;
		this.abilityUnlock = GetComponentInChildren<UnlockAbilityPlayer> ();
		Debug.LogWarning ("Add UnlockAbilityPlayer", gameObject);
	}
	protected virtual void LoadPassiveAbilityPlayerCtrl(){
		if (this.passiveAbilityPlayerCtrl != null)
			return;
		this.passiveAbilityPlayerCtrl = GetComponentInChildren<PassiveAbilityPlayerCtrl> ();
		Debug.LogWarning ("Add PassiveAbilityPlayerCtrl", gameObject);
	}
}
