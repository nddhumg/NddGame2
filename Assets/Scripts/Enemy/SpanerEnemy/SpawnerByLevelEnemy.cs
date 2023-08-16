using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerByLevelEnemy : NddBehaviour {
	[SerializeField]protected int numberSpawn = 10;
	[SerializeField] protected float delaySpawn = 3f;
	[SerializeField] protected float timerSpawn = 0f;
	[SerializeField] protected int levelNow;
	[SerializeField] protected SpawnEnemyCtrl spawnEnemyCtrl;
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadSpawnEnemyCtrl();
	}
	protected override void ResetValue ()
	{
		base.ResetValue ();

	}
	protected virtual void LoadSpawnEnemyCtrl(){
		if (this.spawnEnemyCtrl != null)
			return;
		this.spawnEnemyCtrl= transform.parent.GetComponent<SpawnEnemyCtrl>();
		Debug.Log ("Add SpawnEnemyCtrl", gameObject);
	}
	void FixedUpdate(){
		this.DelaySpawnEnemy ();
		levelNow = (int)LevelMap.Instance.LevelCurrent;
	}
	protected virtual void  DelaySpawnEnemy(){
		if (!SpawnEnemy.Instance.IsSpawnEnemy)
			return;
		timerSpawn += Time.fixedDeltaTime;
		if (timerSpawn < delaySpawn) {
			return;
		}
		SpawnByTurn();
		timerSpawn = 0;
	}
	protected virtual void SpawnByTurn()
	{
		SpawnEnemy spawnE =SpawnEnemy.Instance;
		int numberEnemySpawn = numberSpawn;
		if (spawnE.MaxNumberSpawn - spawnE.NumberOfEnemy < numberSpawn) {
			numberEnemySpawn = spawnE.MaxNumberSpawn - spawnE.NumberOfEnemy;
		}
		for (int i = 0; i < numberEnemySpawn; i++) {
			SpawnByLevel ();
		}
		 
	}
	protected virtual void SpawnByLevel(){
		
		List<Transform> listPointSpawn = spawnEnemyCtrl.SpawnEnemyPoint.PointSpawn;
		SpawnEnemy spawnE = spawnEnemyCtrl.SpawnEnemy;
		int randomPosSpawn = Random.Range (0, listPointSpawn.Count);
		Vector3 posSpawn = listPointSpawn[randomPosSpawn].position;
		GameObject prefabSpawn = spawnEnemyCtrl.ManagerRatioEnemyLevel.GetRandomEnemyInThisLevel (this.levelNow);
		if (prefabSpawn == null) {
			return;
		}
		if (prefabSpawn.name == EnemyName.GoblinKing.ToString ()) {
			if (spawnE.NumberOfEnemyArc >= spawnE.MaxNumberEnemyArc)
				return;
			spawnE.IncreaseTheNumberofEnemyArc ();
		}
		spawnE.Spawn(prefabSpawn, posSpawn, Quaternion.identity);
		spawnE.IncreaseTheNumberofEnemy();
		
	}
}

