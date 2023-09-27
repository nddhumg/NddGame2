using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAbility : NddBehaviour {
	[Header("Base Ability")]
	[SerializeField] protected Ability ability;
	public Ability Ability{
		get{ 
			return ability;
		}
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadAbility ();
	}
	protected virtual void LoadAbility(){
		if (this.ability != null)
			return;
		this.ability = transform.parent.parent.GetComponent<Ability> ();
		Debug.LogWarning ("Add Ability", gameObject);
	}
}
