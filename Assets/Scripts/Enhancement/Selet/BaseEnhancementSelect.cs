using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnhancementSelect : NddBehaviour{
	[Header("Base EnhancementSelect")]
	[SerializeField]protected EnhancementSelectCtrl enhancementSelectCtrl;
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadEnhancementSelectCtrl ();
	}
	protected virtual void LoadEnhancementSelectCtrl(){
		if (this.enhancementSelectCtrl != null)
			return;
		this.enhancementSelectCtrl= transform.parent.GetComponent<EnhancementSelectCtrl>();
		Debug.LogWarning ("Add EnhancementSelectCtrl", gameObject);
	}
}
