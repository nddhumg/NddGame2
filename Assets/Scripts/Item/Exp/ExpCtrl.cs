using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpCtrl : GameObjCtrl {
	[SerializeField] protected ExpSO expSO;
	[SerializeField] protected DestroyExp destroyExp;
	public ExpSO ExpSO{
		get{
			return expSO;
		}
	}
	public DestroyExp DestroyExp{
		get{
			return destroyExp;
		}
	}
	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadExpSO ();
		this.LoadDestroyExp ();
	}
	protected virtual void LoadExpSO(){
		if (this.expSO  != null)
			return;
		string resPath = "ScriptableObject/Exp/" +	transform.name;
		this.expSO = Resources.Load<ExpSO> (resPath);
		Debug.LogWarning (transform.name + " LoadExpSO " + resPath, gameObject);
	}
	protected virtual void LoadDestroyExp(){
		if (this.destroyExp != null)
			return;
		this.destroyExp= GetComponentInChildren<DestroyExp>();
		Debug.LogWarning ("Add DestroyItem", gameObject);
	}
}
