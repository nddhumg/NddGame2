using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBossDamageReceiver : DamageReceiverEnemy{
	[Header("SlimeBossDamageReceiver")]
	[SerializeField] protected SlimeBossCtrl slimeBossCtrl;

	protected override void OnDead(){
		base.OnDead();
		slimeBossCtrl.SlimeBossAbilityCtrl.SlimeBossCloneAbility.AbilityCloneSlimeBoss();
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadSlimeBossCtrl ();
	}
	protected virtual void LoadSlimeBossCtrl(){
		if(this.slimeBossCtrl != null)
			return;
		this.slimeBossCtrl = transform.parent.GetComponent<SlimeBossCtrl> ();
		Debug.LogWarning ("Add SlimeBossCtrl", gameObject);
	}
}
