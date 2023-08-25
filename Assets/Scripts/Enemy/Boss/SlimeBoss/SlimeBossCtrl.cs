using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBossCtrl : BossCtrl {
	[Header("Slime Boss")]
	[SerializeField] protected SlimeBossAbilityCtrl slimeBossAbilityCtrl;
	public SlimeBossAbilityCtrl SlimeBossAbilityCtrl{
		get{ 
			return slimeBossAbilityCtrl;
		}
	}
	protected override void LoadComponent(){
		base.LoadComponent();
		this.LoadSlimeBossAbilityCtrl ();
	}
	protected virtual void LoadSlimeBossAbilityCtrl(){
		if(this.slimeBossAbilityCtrl != null)
			return;
		this.slimeBossAbilityCtrl = GetComponentInChildren<SlimeBossAbilityCtrl> ();
		Debug.LogWarning ("Add SlimeBossAbilityCtrl", gameObject);
	}
}
