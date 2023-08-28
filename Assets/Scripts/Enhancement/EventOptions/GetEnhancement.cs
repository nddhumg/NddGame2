using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GetEnhancement :  NddBehaviour,IEvenetEnhancementSelection {
	[Header("Get Enhancement")]
	[SerializeField] protected EnhancementOptions enhancementOptions;
	[SerializeField] protected AbilityCtrl abilityCtrl;
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadEnhancementOptions ();
		this.LoadAbilityCtrl ();
	}
	protected virtual void LoadEnhancementOptions(){
		if (this.enhancementOptions != null)
			return;
		this.enhancementOptions= GameObject.Find("EnhancementOptionsEvent").GetComponent<EnhancementOptions>();
		Debug.LogWarning ("Add EnhancementOptions", gameObject);
	}
	protected virtual void LoadAbilityCtrl(){
		if (this.abilityCtrl != null)
			return;
		this.abilityCtrl= transform.parent.GetComponentInChildren<AbilityCtrl>();
		Debug.LogWarning ("Add AbilityCtrl", gameObject);
	}
	protected virtual void OnEnable(){
		enhancementOptions.AddObsever (this);
	}
	protected virtual void OnDisable(){
		enhancementOptions.RemoveObsever (this);
	}
	public abstract void OnSelectionEnhancement (EnhancementCode select);

}
