using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnsPoolOgj : NddBehaviour {
	[Header("SpawnsPrefab")]

	[SerializeField]protected List<Transform> listPrefabs;
	public List<Transform> ListPrefabs{
		get{
			return listPrefabs;
		}
	}

	[SerializeField]protected Transform prefabs;
	[SerializeField]protected Transform holder;
	[SerializeField]protected Transform waiter;

	[SerializeField]protected List<Transform> poolOgj;
	protected override void LoadComponent(){
		this.LoadPrefabs ();
		this.LoadListPrefabs ();
		this.LoadHolder ();
		this.LoadWaiter ();
	}

	protected virtual void LoadHolder(){
		if (this.holder != null)
			return;
		this.holder = transform.Find ("Holder");
		Debug.Log ("Add Holder", gameObject);
	}
	protected virtual void LoadWaiter(){
		if (this.waiter != null)
			return;
		this.waiter = transform.Find ("Waiter");
		Debug.Log ("Add Waiter", gameObject);
	}
	protected virtual void LoadPrefabs(){
		if (this.prefabs != null)
			return;
		this.prefabs = transform.Find ("Prefabs");
		Debug.Log ("Add Prefabs", gameObject);
	}

	protected virtual void LoadListPrefabs(){
		if (listPrefabs.Count > 0)
			return;
		if(this.prefabs == null){
			Debug.LogError ("Not obj name: Prefabs", transform);
			return;
		}
		foreach (Transform obj in this.prefabs) {
			listPrefabs.Add (obj);
		}
		foreach (Transform obj in listPrefabs) {
			obj.gameObject.SetActive (false);
		}
	}
		
	public virtual void DesTroyPrefabs(Transform obj){
		obj.gameObject.SetActive (false);
		poolOgj.Add (obj);
		obj.parent = this.waiter;
	}
	protected Transform SpawnPool(string nameSpawn){
		foreach (Transform obj in this.poolOgj) {
			if (obj.name == nameSpawn) {
				poolOgj.Remove (obj);
				obj.gameObject.SetActive (true);
				return obj;
			}
		}
		return null;
	}
	protected Transform SpawnInstantiate(string nameSpawn){
		foreach (Transform obj in this.listPrefabs) {
			if (obj.name == nameSpawn) {
				Transform newObj = Instantiate (obj);
				newObj.name = nameSpawn;
				return newObj;
			}
		}
		return null;
	}
	public virtual Transform Spawn(string namePrefab, Vector3 pos, Quaternion rot){
		Transform newObj = this.SpawnPool(namePrefab);
		if (newObj == null) {
			newObj = SpawnInstantiate (namePrefab);
		}
		if (newObj == null) {
			Debug.LogWarning ("Dont obj by name: " +namePrefab, gameObject);
		}else{
			newObj.gameObject.SetActive (true);
			newObj.parent = this.holder;
			newObj.SetPositionAndRotation (pos, rot);
		}
		return newObj;
	}
	public virtual Transform Spawn(GameObject preafab, Vector3 pos, Quaternion rot){
		return this.Spawn (preafab.name, pos, rot);
	}
}
