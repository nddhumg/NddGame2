using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpCtrl : ItemCtrl {
	[SerializeField] protected ExpSO expSO;
	public ExpSO ExpSO{
		get{
			return expSO;
		}
	}

	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadExpSO ();
	}
	protected virtual void LoadExpSO(){
		if (this.expSO  != null)
			return;
		string resPath = "ScriptableObject/Exp/" +	transform.name;
		this.expSO = Resources.Load<ExpSO> (resPath);
		Debug.LogWarning (transform.name + " LoadExpSO " + resPath, gameObject);
	}

}
