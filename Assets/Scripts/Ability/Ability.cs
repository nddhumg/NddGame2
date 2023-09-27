using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : NddBehaviour {
	[SerializeField] protected GameObjCtrl objectCtrl;
	public GameObjCtrl ObjectCtrl{
		get{
			return objectCtrl;
		}
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadObjectCtrl ();
	}
	protected virtual void LoadObjectCtrl(){
		if (this.objectCtrl != null)
			return;
		this.objectCtrl = transform.parent.GetComponent<GameObjCtrl> ();
		Debug.LogWarning ("Add ObjectCtrl", gameObject);
	}
}
