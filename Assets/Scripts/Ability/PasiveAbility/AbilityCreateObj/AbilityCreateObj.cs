using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityCreateObj : NddBehaviour {
	[SerializeField] protected GameObject prefab;

	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadPrefabs ();
	}
	protected virtual void LoadPrefabs(){
		if (prefab != null)
			return;
		prefab = transform.Find ("Prefab").gameObject;
		Debug.LogWarning ("Add prefab", gameObject);
	}
	protected virtual GameObject CreateObj(Vector3 position, Quaternion rotation){
		GameObject obj = Instantiate(prefab, position, rotation);
		obj.SetActive (true);
		return obj;
	} 
}
