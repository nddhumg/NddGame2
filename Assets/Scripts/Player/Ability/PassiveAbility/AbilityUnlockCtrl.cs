using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUnlockCtrl : NddBehaviour {
	[SerializeField] protected LevelAbility level;
	[SerializeField] protected DamagePlayerAbility damagePlayer;
	public DamagePlayerAbility DamagePlayerAbility{
		get{
			return damagePlayer;
		}
	}
	public LevelAbility LevelAbility{
		get{
			return level;
		}
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadLevelAbility ();
		LoadDamagePlayerAbility ();
	}
	protected virtual void LoadDamagePlayerAbility(){
		if (this.damagePlayer != null)
			return;
		this.damagePlayer= GetComponentInChildren<DamagePlayerAbility>();
		Debug.LogWarning ("Add damagePlayer", gameObject);
	}
	protected virtual void LoadLevelAbility(){
		if (this.level != null)
			return;
		this.level= GetComponentInChildren<LevelAbility>();
		Debug.LogWarning ("Add LevelAbility", gameObject);
	}
}
