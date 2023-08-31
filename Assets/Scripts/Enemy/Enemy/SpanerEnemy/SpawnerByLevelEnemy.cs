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
			SpawnByLevel();
		}
		 
	}

	protected virtual void SpawnByLevel(){
		SpawnEnemy spawnE = spawnEnemyCtrl.SpawnEnemy;
		Vector3 posSpawn = this.GetPosisionRandomSpawnEnemy();
		string prefabNameSpawn = spawnEnemyCtrl.ManagerEnemySpawnByLevel.GetRandomEnemyNameSpawnByLevel (this.levelNow);
		if (prefabNameSpawn == null) {
			Debug.LogWarning ("Dont enemy spawn in level" + this.levelNow, gameObject);
			return;
		}
		if (prefabNameSpawn == EnemyName.GoblinKing.ToString ()) {
			if (this.isMaxEnemyArc (spawnE)) {
				return;
			}
			spawnE.IncreaseTheNumberofEnemyArc ();
		}
		Spawn (spawnE,prefabNameSpawn,posSpawn,Quaternion.identity);
	}
	protected virtual bool isMaxEnemyArc(SpawnEnemy spawnEnemy){
		return spawnEnemy.NumberOfEnemyArc >= spawnEnemy.MaxNumberEnemyArc;
	}
	protected virtual void Spawn(SpawnEnemy spawnEnemy,string enemyName,Vector3 posSpawn,Quaternion rotSpawn){
		spawnEnemy.Spawn(enemyName, posSpawn,rotSpawn);
		spawnEnemy.IncreaseTheNumberofEnemy();
	}
	protected virtual Vector3 GetPosisionRandomSpawnEnemy(){
		List<Transform> listPointSpawn = spawnEnemyCtrl.SpawnEnemyPoint.PointSpawn;
		int randomPosSpawn = Random.Range (0, listPointSpawn.Count);
		return listPointSpawn[randomPosSpawn].position;
	}
}

