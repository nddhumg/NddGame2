using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAbilityHolySword : LevelAbility {
	[SerializeField] protected AbilityHolySwordPlayerCtrl ctrl;
	protected override void Start ()
	{
		base.Start ();
		LevelAbilityUp ();
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadAbilityHolySwordPlayerCtrl ();
	}
	protected virtual void LoadAbilityHolySwordPlayerCtrl(){
		if (ctrl != null)
			return;
		ctrl = transform.parent.GetComponent<AbilityHolySwordPlayerCtrl> ();
		Debug.LogWarning ("Add AbilityHolySwordPlayerCtrl", gameObject);
	}
	public override void LevelAbilityUp(){
		int nextLevel = (int)levelCurrent+1;
		switch (nextLevel) 
		{
		case 1:
			ctrl.Manager.InstantiatePrab();
			break;
		case 2:
			ctrl.DamagePlayerAbility.SetDamageRatio(2f);
			break;
		case 3:
			ctrl.Manager.InstantiatePrab ();
			ctrl.Manager.IncreaseSpeedObj (3f);
			break;
		case 4:
			ctrl.Manager.IncreaseSpeedObj (3f);
			ctrl.DamagePlayerAbility.SetDamageRatio(4f);
			break;
		case 5:
			ctrl.Manager.InstantiatePrab ();
			ctrl.Manager.IncreaseSpeedObj (7f);
			ctrl.DamagePlayerAbility.SetDamageRatio(7f);
			break;
		default:
			return;
		}
		LevelUp ();
	}
}
