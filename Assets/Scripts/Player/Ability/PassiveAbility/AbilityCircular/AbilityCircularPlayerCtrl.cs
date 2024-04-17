using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCircularPlayerCtrl : AbilityUnlockCtrl {
	[SerializeField] protected AbilityCircularPlayer abilityCircularPlayer;
	public AbilityCircularPlayer AbilityCircularPlayer{
		get{
			return abilityCircularPlayer;
		}
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadAbilityCircularPlayer ();
	}
	protected virtual void LoadAbilityCircularPlayer(){
		if (this.abilityCircularPlayer != null)
			return;
		this.abilityCircularPlayer= GetComponent<AbilityCircularPlayer>();
		Debug.LogWarning ("Add AbilityCircularPlayer", gameObject);
	}
}
