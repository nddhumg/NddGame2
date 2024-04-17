using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgAbilityHolySwordPlayer : DamagePlayerAbility {
	[SerializeField] protected AbilityHolySwordPlayerCtrl ctrl;
	public override void OnSetDamage (float damagePlayer)
	{
		base.OnSetDamage (damagePlayer);
		ctrl.Manager.SetDamageObj (damage);
	}
	public override void SetDamageRatio (float damageRatio)
	{
		base.SetDamageRatio (damageRatio);
		ctrl.Manager.SetDamageObj (damage);
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadAbilityHolySwordPlayerCtrl ();
	}
	protected virtual void LoadAbilityHolySwordPlayerCtrl(){
		if (ctrl != null) {
			return;
		}
		ctrl = transform.parent.GetComponent<AbilityHolySwordPlayerCtrl> ();
		Debug.LogWarning ("Add AbilityHolySwordPlayerCtrl", gameObject);
	}
}
