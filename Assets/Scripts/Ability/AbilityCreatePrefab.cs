using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCreatePrefab : NddBehaviour {
	[SerializeField] protected List<Transform> ObjAbility = new List<Transform>();
	[SerializeField] protected GameObject prefab;
	[SerializeField] protected int maxPrefab = 5;

	public virtual GameObject InstantiatePrab(){
		if (IsMaxPrefab ()){
			Debug.LogWarning("Maximum obj prefab.Dont Instantiate obj",gameObject);
			return null;
		}
		GameObject newPrefab = Instantiate(prefab);
		newPrefab.SetActive (true);
		ObjAbility.Add (newPrefab.transform);
		return newPrefab;
	}
	public virtual void InstantiatePrab(int value){
		for(int temp = 1;temp <= value; temp++){
			if (InstantiatePrab () == null) {
				break;
			}
		}
	}

	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadPrefab ();
	}
	protected virtual void LoadPrefab(){
		if(prefab != null)
			return;
		prefab = transform.Find ("Prefab").gameObject;
		Debug.LogWarning ("Add prefab", gameObject);
	}

	protected virtual bool IsMaxPrefab(){
		return ObjAbility.Count >= maxPrefab;
	}
}
