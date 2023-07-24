using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractExp : NddBehaviour {
	[SerializeField] protected ExpCtrl expCtrl;
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadExpCtrl ();
	}
	protected virtual void LoadExpCtrl(){
		if (this.expCtrl != null)
			return;
		this.expCtrl= transform.parent.GetComponent<ExpCtrl>();
		Debug.LogWarning ("Add ExpCtrl", gameObject);
	}
}
