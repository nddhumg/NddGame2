using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNdd : NddBehaviour {
	[Header("Spawn")]
	[SerializeField]private Transform prefabs;
	[SerializeField]protected List<Transform> listPrefabs;
	[SerializeField]protected Transform holder;

	protected override void LoadComponent(){
		this.LoadPrefabs ();
		this.LoadListPrefabs ();
		this.LoadHolder ();
	}
	private  void LoadHolder(){
		if (this.holder != null)
			return;
		this.holder = transform.Find ("Holder");
		Debug.LogWarning ("Add Holder", gameObject);
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
	protected virtual void LoadPrefabs(){
		if (this.prefabs != null)
			return;
		this.prefabs = transform.Find ("Prefabs");
		Debug.LogWarning ("Add Prefabs", gameObject);
	}
	protected void SetUpOnjSpawn(Transform newObj,string name){
		newObj.name = name;
		newObj.gameObject.SetActive (true);
		newObj.parent = this.holder;
	}
	public virtual Transform Spawn(string namePrefab, Vector3 pos, Quaternion rot){
		foreach (Transform obj in this.listPrefabs) {
			if (obj.name == namePrefab) {
				Transform newObj = Instantiate (obj,pos,rot);
				SetUpOnjSpawn (newObj, namePrefab);
				return newObj;
			}
		}
		Debug.LogWarning ("Dont prefab by name in list: " + namePrefab, gameObject);
		return null;
	}
	public virtual Transform Spawn(GameObject gameObjectPrefab, Vector3 pos, Quaternion rot){
		return Spawn (gameObjectPrefab.name, pos, rot);
	}
	public virtual Transform Spawn(string namePrefab){
		foreach (Transform obj in this.listPrefabs) {
			if (obj.name == namePrefab) {
				Transform newObj = Instantiate (obj);
				SetUpOnjSpawn (newObj, namePrefab);
				return newObj;
			}
		}
		return null;
	}
}
