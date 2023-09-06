using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyPoint : NddBehaviour {
	[SerializeField] protected List<Transform> pointSpawn;
	private static SpawnEnemyPoint instance;
	public static SpawnEnemyPoint Instance{
		get{
			return instance;
		}
	}
	protected override void LoadSingleton() {
		if (SpawnEnemyPoint.instance != null) {
			Debug.LogWarning("Only 1 SpawnEnemyPoint allow to exist");
		}
		SpawnEnemyPoint.instance = this;
	}

	public List<Transform> PointSpawn{
		get{
			return pointSpawn;
		}
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadPointSpawnEnemy ();
	}
	protected virtual void LoadPointSpawnEnemy(){
		if (pointSpawn.Count > 0)
			return;
		Transform posSpawnEnemy = GameObject.Find ("PosSpawnEnemy").transform;
		foreach (Transform posEnemy in posSpawnEnemy) {
			pointSpawn.Add (posEnemy);
		}
	}
	public virtual Transform GetRandomPoinSpawn(){
		int indexRandomPoint = Random.Range (0, pointSpawn.Count);
		return pointSpawn [indexRandomPoint];
	}
}
