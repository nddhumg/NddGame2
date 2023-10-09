using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCircularPlayerCtrl : NddBehaviour {
	[SerializeField] protected AbilityCircularPlayer abilityCircularPlayer;
	[SerializeField] protected AbilityCircularLevelPlayer abilityCircularLevelPlayer;
	public AbilityCircularPlayer AbilityCircularPlayer{
		get{
			return abilityCircularPlayer;
		}
	}
	public AbilityCircularLevelPlayer AbilityCircularLevelPlayer{
		get{
			return abilityCircularLevelPlayer;
		}
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadAbilityCircularPlayer ();
		LoadAbilityCircularLevelPlayer ();
	}
	protected virtual void LoadAbilityCircularPlayer(){
		if (this.abilityCircularPlayer != null)
			return;
		this.abilityCircularPlayer= GetComponent<AbilityCircularPlayer>();
		Debug.Log ("Add AbilityCircularPlayer", gameObject);
	}
	protected virtual void LoadAbilityCircularLevelPlayer(){
		if (this.abilityCircularLevelPlayer != null)
			return;
		this.abilityCircularLevelPlayer= GetComponentInChildren<AbilityCircularLevelPlayer>();
		Debug.Log ("Add AbilityCircularLevelPlayer", gameObject);
	}
}
