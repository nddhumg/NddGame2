using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnsPoolOgj : SpawnNdd {
	[Header("Spawn Pool")]

	[SerializeField]protected Transform waiter;
	[SerializeField]protected List<Transform> poolOgj;

	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadWaiter ();
	}
	private  void LoadWaiter(){
		if (this.waiter != null)
			return;
		this.waiter = transform.Find ("Waiter");
		Debug.LogWarning ("Add Waiter", gameObject);
	}
	public virtual void DesTroyPrefabs(Transform obj){
		obj.gameObject.SetActive (false);
		poolOgj.Add (obj);
		obj.parent = this.waiter;
	}
	private Transform SpawnPool(string nameSpawn){
		foreach (Transform obj in this.poolOgj) {
			if (obj.name == nameSpawn) {
				poolOgj.Remove (obj);
				obj.gameObject.SetActive (true);
				return obj;
			}
		}
		return null;
	}
	private Transform SpawnInstantiate(string nameSpawn){
		foreach (Transform obj in this.listPrefabs) {
			if (obj.name == nameSpawn) {
				Transform newObj = Instantiate (obj);
				newObj.name = nameSpawn;
				return newObj;
			}
		}
		return null;
	}
	public override Transform Spawn(string namePrefab, Vector3 pos, Quaternion rot){
		Transform newObj = this.SpawnPool(namePrefab);
		if (newObj == null) {
			newObj = SpawnInstantiate (namePrefab);
		}

		if (newObj == null) {
			Debug.LogWarning ("Dont prefab by name in list: " + namePrefab, gameObject);
		}else{
			newObj.gameObject.SetActive (true);
			newObj.parent = this.holder;
			newObj.SetPositionAndRotation (pos, rot);
		}
		return newObj;
	}
}
