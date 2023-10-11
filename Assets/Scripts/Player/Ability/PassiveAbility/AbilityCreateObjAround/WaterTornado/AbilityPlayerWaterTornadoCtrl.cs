using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPlayerWaterTornadoCtrl : NddBehaviour {
	[SerializeField] protected AbilityPlayerWaterTornado abilityPlayerWaterTornado;
	[SerializeField]protected LevelAbilityPlayerWaterTornado levelAbilityPlayerWaterTornado;
	[SerializeField] protected DamagePlayerAbility damagePlayerAbility;
	public AbilityPlayerWaterTornado AbilityPlayerWaterTornado{
		get{ 
			return abilityPlayerWaterTornado;
			}
	}
	public LevelAbilityPlayerWaterTornado LevelAbilityPlayerWaterTornado{
		get{ 
			return levelAbilityPlayerWaterTornado;
		}
	}
	public DamagePlayerAbility DamagePlayerAbility{
		get{ 
			return damagePlayerAbility;
		}
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadAbilityPlayerWaterTornado();
		LoadLevelAbilityPlayerWaterTornado ();
		LoadDamagePlayerAbility ();
	}
	protected virtual void LoadAbilityPlayerWaterTornado(){
		if (this.abilityPlayerWaterTornado != null)
			return;
		this.abilityPlayerWaterTornado= GetComponent<AbilityPlayerWaterTornado>();
		Debug.LogWarning ("Add AbilityPlayerWaterTornado", gameObject);
	}
	protected virtual void LoadLevelAbilityPlayerWaterTornado(){
		if (this.levelAbilityPlayerWaterTornado != null)
			return;
		this.levelAbilityPlayerWaterTornado= transform.GetComponentInChildren<LevelAbilityPlayerWaterTornado>();
		Debug.LogWarning ("Add LevelAbilityPlayerWaterTornado", gameObject);
	}
	protected virtual void LoadDamagePlayerAbility(){
		if (this.damagePlayerAbility != null)
			return;
		this.damagePlayerAbility= transform.GetComponentInChildren<DamagePlayerAbility>();
		Debug.LogWarning ("Add DamagePlayerAbility", gameObject);
	}
}
