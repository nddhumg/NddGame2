using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPlayerCtrl : NddBehaviour {
	[SerializeField] protected UnlockAbilityPlayer abilityUnlock;
	public UnlockAbilityPlayer AbilityUnlock{
		get{
			return abilityUnlock;
		}
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadUnlockAbilityPlayer ();
	}
	protected virtual void LoadUnlockAbilityPlayer(){
		if (this.abilityUnlock != null)
			return;
		this.abilityUnlock = GetComponentInChildren<UnlockAbilityPlayer> ();
		Debug.LogWarning ("Add UnlockAbilityPlayer", gameObject);
	}
}
