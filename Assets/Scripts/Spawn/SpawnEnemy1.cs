using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy1 : SpawnsPoolOgj {
	[SerializeField] protected float delaySpawn = 4f;
	[SerializeField] protected int numberSpawn =10 ;
	[SerializeField] protected int maxNumberSpawn = 200;
	[SerializeField] protected List<Transform> poSpawns;
	[SerializeField] protected string enemy_1 = "Enemy1";

	private static SpawnEnemy1 instance;
	public static SpawnEnemy1 Instance{
		get{
			return instance;
		}
	}
	protected override void Start(){
		StartCoroutine (SpawnEnemy ());
	}
	protected override void LoadSingleton() {
		if (SpawnEnemy1.instance != null) {
			Debug.LogError("Only 1 SoawnEnemy allow to exist");
		}
		SpawnEnemy1.instance = this;
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadPosSpawnEnemy ();
	}

	protected virtual void LoadPosSpawnEnemy(){
		if (poSpawns.Count > 0)
			return;
		Transform posSpawnEnemy = GameObject.Find ("PosSpawnEnemy").transform;
		foreach (Transform posEnemy in posSpawnEnemy) {
			poSpawns.Add (posEnemy);
		}
	}
	IEnumerator SpawnEnemy(){
		while (true) {
			for (int i = 0; i < numberSpawn; i++) {
				int randomPosSpawn = Random.Range (0, poSpawns.Count);
				Vector3 posSpawn = poSpawns [randomPosSpawn].position;
				Spawn (enemy_1, posSpawn, Quaternion.identity);
			}
			yield return new WaitForSeconds (delaySpawn);
		}
	}

		
}

