using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpCtrl : NddBehaviour {
	[SerializeField] protected ExpSO expSO;
	public ExpSO ExpSO{
		get{
			return expSO;
		}
	}
	[SerializeField]private DestroyExp destroyExp;
	public  DestroyExp DestroyExp{
		get{
			return destroyExp;
		}
	}

	private static ExpCtrl instance;
	public static ExpCtrl Instance{
		get{
			return instance;
		}
	}

	protected override void LoadSingleton() {
		if (ExpCtrl.instance != null) {
			Debug.LogError ("Only 1 ExpCtrl allow to exist");
		}
		ExpCtrl.instance = this;
	}

	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadDestroyExp ();
		this.LoadExpSO ();
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
		Debug.LogWarning ("Add DestroyExp", gameObject);
	}
}
