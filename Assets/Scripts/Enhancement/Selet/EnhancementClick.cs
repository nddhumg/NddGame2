using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhancementClick :  BaseEnhancementSelect {
	[SerializeField] protected Collider2D collider2d;
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadCollider ();
	}
	protected virtual void LoadCollider(){
		if (collider2d != null)
			return;
		collider2d = GetComponent<Collider2D> ();
		collider2d.isTrigger = true;
		Debug.LogWarning ("Add Collider2D",gameObject);
	}
	protected void OnMouseDown(){
		EnhancementCode nameEnhancementSelect = enhancementSelectCtrl.EnhancementSelectProperties.NameEnhancementSelect;
//		Debug.Log (nameEnhancementSelect.ToString());
		EnhancementOptions.Instance.SelectEnhacement (nameEnhancementSelect);
		EnhancementSelectManager.Instance.SetActiveEnhancementSelect (false);
	}	

}
 