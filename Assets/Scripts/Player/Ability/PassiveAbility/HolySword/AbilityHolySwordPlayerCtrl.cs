using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolySwordPlayerCtrl : AbilityUnlockCtrl {
	[SerializeField] protected AbillityHolySwordPlayerManager manager;
	public AbillityHolySwordPlayerManager Manager{
		get{ 
			return manager;
		}
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadAbillityHolySwordPlayerManager ();
	}
	protected virtual void LoadAbillityHolySwordPlayerManager(){
		if (manager != null)
			return;
		manager = transform.GetComponent<AbillityHolySwordPlayerManager> ();
		Debug.LogWarning ("Add AbillityHolySwordPlayerManager", gameObject);
	}
}
