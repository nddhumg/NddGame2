using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAbilityCircularPlayer : DamagePlayerAbility {
	[SerializeField] protected AbilityCircularPlayer abilityCircularPlayer;
	public override void OnSetDamage (float damagePlayer)
	{
		base.OnSetDamage (damagePlayer);
		abilityCircularPlayer.SetDamageObj ();
	}
	public override void SetDamageRatio (float damageRatio)
	{
		base.SetDamageRatio (damageRatio);
		abilityCircularPlayer.SetDamageObj ();
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadAbilityCircularPlayer ();
	}
	protected virtual void LoadAbilityCircularPlayer(){
		if (abilityCircularPlayer != null) {
			return;
		}
		abilityCircularPlayer = transform.parent.GetComponent<AbilityCircularPlayer> ();
		Debug.LogWarning ("Add AbilityCircularPlayer", gameObject);
	}

}
