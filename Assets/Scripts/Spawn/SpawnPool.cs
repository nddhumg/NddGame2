﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class SpawnPool : NddBehaviour{
	[System.Serializable]
	public class Pool{
		public string tag;
		public GameObject prefab;

		public void CheckTag(){
			if (tag != prefab.name)
				Debug.LogError ("Tag mismatch: " + tag + " != " + prefab.name);
		}
	}
	[SerializeField] protected List<Pool> pools = new List<Pool>();
	[SerializeField] protected Dictionary<string,Queue<GameObject>> poolDictionary;

	[SerializeField] protected Transform waiter;
	[SerializeField] protected Transform holder;

	protected override void Start(){
		base.Start ();

		poolDictionary = new Dictionary<string , Queue<GameObject>> ();

		foreach (Pool pool in pools) {
			pool.CheckTag ();
			Queue<GameObject> objPool = new Queue<GameObject> ();
			poolDictionary.Add (pool.tag, objPool);
		}
	}

	public virtual Transform Spawn(string namePrefab, Vector3 pos, Quaternion rot){
		if (!poolDictionary.ContainsKey (namePrefab)	) {
			Debug.LogWarning ("Pool with tag " + namePrefab + " doesn't excist.");
			return null;
		}
		GameObject obj = null;
		if (poolDictionary [namePrefab].Count > 0) {
			obj = poolDictionary [namePrefab].Dequeue ();
		}
		else{
			foreach (Pool pool in pools) {
				if (pool.tag == namePrefab)
					obj = Instantiate (pool.prefab);
			}
		}
		if (obj == null) {
			Debug.LogError ("Canot create prefab from pool with tag: " + namePrefab);
			return null; 
		}
		obj.transform.SetPositionAndRotation (pos, rot);
		obj.transform.SetParent (holder);
		obj.name = namePrefab;
		obj.SetActive (true);
		return obj.transform;
	}

	public virtual void DesTroyPrefabs(Transform obj){
		obj.gameObject.SetActive (false);
		poolDictionary[obj.name].Enqueue(obj.gameObject);
		obj.parent = waiter;
	}

	protected override void LoadComponent(){
		base.LoadComponent ();
		LoadWaiter ();
		LoadHolder ();
	}

	private  void LoadWaiter(){
		if (this.waiter != null)
			return;
		this.waiter = transform.Find ("Waiter");
		Debug.LogWarning ("Add Waiter", gameObject);
	}

	private  void LoadHolder(){
		if (this.holder != null)
			return;
		this.holder = transform.Find ("Holder");
		Debug.LogWarning ("Add Holder", gameObject);
	}
		
}
