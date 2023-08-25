using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBossAbilityCtrl : NddBehaviour {
	[SerializeField] protected SlimeBossCloneAbility slimeBossCloneAbility;
	public SlimeBossCloneAbility SlimeBossCloneAbility{
		get{ 
			return slimeBossCloneAbility;
		}
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadSlimeBossCloneAbility ();
	}
	protected virtual void LoadSlimeBossCloneAbility(){
		if(this.slimeBossCloneAbility != null)
			return;
		this.slimeBossCloneAbility = GetComponentInChildren<SlimeBossCloneAbility> ();
		Debug.LogWarning ("Add SlimeBossCloneAbility", gameObject);
	}
}
