using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class EnemySpawnRateTest
{
	public EnemyName nameEnemyPrefab = EnemyName.NoName;
	public float percentage;
}
[CreateAssetMenu(fileName = "SpawnEnemyByLevel", menuName = "SO/Spawn/Enemy" +"")]
public class SpawnEnemyByLevelSO : ScriptableObject {
	public string level ;
	public EnemySpawnRateTest[] ArrEnemySpawn;
}
