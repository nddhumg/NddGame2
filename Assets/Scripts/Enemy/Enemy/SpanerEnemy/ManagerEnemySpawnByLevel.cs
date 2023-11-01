using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerEnemySpawnByLevel : NddBehaviour {
	[SerializeField] protected EnemySpawnRateTest[] arrEnemySpawn;  
	[SerializeField] protected int levelPast = 1;
	[SerializeField] protected float overallSpawnRate = 0;

	protected override void Start ()
	{
		base.Start ();
		arrEnemySpawn = GetSpawnEnemyByLevelSO (levelPast);
		this.GetOverallSpawnRateInTheLevelNow ();
	}

	protected virtual EnemySpawnRateTest[] GetSpawnEnemyByLevelSO(int level){
		string resPath = "ScriptableObject/Spawn/Enemy/" + "SpawnEnemyByLevel" + level;
		SpawnEnemyByLevelSO spawnEnemyByLevelSO = Resources.Load<SpawnEnemyByLevelSO> (resPath);
		return spawnEnemyByLevelSO?.ArrEnemySpawn;
	}
	public virtual string GetRandomEnemyNameSpawnByLevel (int keyLevel){
		GetArrEnemySpawn (keyLevel);
		if (arrEnemySpawn == null)
			return null;
		float ranPercemtageEnemySpawn = Random.Range (0f, 1f);
		float temp = 0;

		foreach (EnemySpawnRateTest enemySpawn in arrEnemySpawn) {
			temp += (enemySpawn.percentage / this.overallSpawnRate);
			if (ranPercemtageEnemySpawn <= temp) {
				return enemySpawn.nameEnemyPrefab.ToString ();
			}
		}
		return null;
	}

	protected virtual void GetArrEnemySpawn(int levelNow){
		if (this.levelPast == levelNow)
			return;
		arrEnemySpawn = GetSpawnEnemyByLevelSO(levelNow);
		this.GetOverallSpawnRateInTheLevelNow ();
		levelPast = levelNow;
	}
	protected virtual void GetOverallSpawnRateInTheLevelNow(){
		this.overallSpawnRate = 0;
		if (arrEnemySpawn.Length <= 0) {
			return;
		}
		foreach (EnemySpawnRateTest enemySpawn in arrEnemySpawn) {
			this.overallSpawnRate += enemySpawn.percentage;
		}
	}
}
