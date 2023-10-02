using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCircularLevelPlayer : LevelAbility {
	[SerializeField] protected AbilityCircularPlayerCtrl abilityCircularPlayerCtrl;
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadAbilityCircularPlayerCtrl ();
	}
	protected virtual void LoadAbilityCircularPlayerCtrl(){
		if (abilityCircularPlayerCtrl != null)
			return;
		abilityCircularPlayerCtrl = transform.parent.GetComponent<AbilityCircularPlayerCtrl> ();
		Debug.Log ("Add AbilityCircularPlayerCtrl", gameObject);
	}
	public override void LevelAbilityUp(){
		int nextLevel = (int)levelCurrent+1;
		switch (nextLevel) 
		{
		case 2:
			abilityCircularPlayerCtrl.AbilityCircularPlayer.DamageRatio = 1.2f;	
			break;

		case 3:
			abilityCircularPlayerCtrl.AbilityCircularPlayer.InstantiatePrab ();
			break;

		case 4:
			abilityCircularPlayerCtrl.AbilityCircularPlayer.Speed = 2.3f;
			abilityCircularPlayerCtrl.AbilityCircularPlayer.Radius = 3.5f;
			break;

		case 5:
			abilityCircularPlayerCtrl.AbilityCircularPlayer.InstantiatePrab ();
			abilityCircularPlayerCtrl.AbilityCircularPlayer.DamageRatio = 2f;	
			break;
		default:
			return;
		}
		LevelUp ();
	}
}
