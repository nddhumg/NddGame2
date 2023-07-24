using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class EnemySpawnRate
{
	public EnemyName nameEnemyPrefab = EnemyName.NoName;
	public GameObject prefab;
	public float[] percentage ;
}
public class ManagerRatioEnemyLevel : NddBehaviour {
	[SerializeField]protected EnemySpawnRate[] enemySpawnInThisLevel = new EnemySpawnRate[6];
	[SerializeField]protected List<Transform> listPrefabs;
	[SerializeField]protected float numberRandom;
	private static ManagerRatioEnemyLevel instance;
	public static ManagerRatioEnemyLevel Instance{
		get{
			return instance;
		}
	}
	protected override void LoadSingleton() {
		if (ManagerRatioEnemyLevel.instance != null) {
			Debug.LogWarning("Only 1 ManagerRatioEnemyLevel allow to exist");
		}
		ManagerRatioEnemyLevel.instance = this;
	}
	protected override void LoadComponent(){
		this.LoadListPrefabs ();
		this.SetUpData ();

	}
	protected virtual void LoadListPrefabs(){
		if (this.listPrefabs.Count > 0)
			return;
		Transform prefab = transform.parent.Find ("Prefabs");
		foreach (Transform obj in prefab) {
			this.listPrefabs.Add (obj);
		}
		Debug.LogWarning("Add ListPrefabs");
	}
	public virtual GameObject GetRandomEnemyInThisLevel(int levelNow)
	{
		numberRandom = Random.Range (0f, 1f);
		float temp = 0;
		foreach (EnemySpawnRate enemy in enemySpawnInThisLevel) {
			//TODO LevelNow >= max
			temp += enemy.percentage [levelNow];
			if (temp >= numberRandom)
				return enemy.prefab;
		}
		return null;
	}
	protected virtual void SetUpData(){
		SetArrNamesEnemy ();
		SetArrPrefabsEnemy ();
	} 
	protected virtual void SetArrNamesEnemy(){
		enemySpawnInThisLevel [0].nameEnemyPrefab = EnemyName.Slime;
		enemySpawnInThisLevel [1].nameEnemyPrefab = EnemyName.GoblinKing;
		enemySpawnInThisLevel [2].nameEnemyPrefab = EnemyName.Ork1;
		enemySpawnInThisLevel [3].nameEnemyPrefab = EnemyName.Minotaur;
		enemySpawnInThisLevel [4].nameEnemyPrefab = EnemyName.Ork2;
		enemySpawnInThisLevel [5].nameEnemyPrefab = EnemyName.Ork3;
	}
	protected virtual void SetArrPrefabsEnemy(){
		foreach (EnemySpawnRate enemy in enemySpawnInThisLevel) {
			foreach (Transform prefabInList in listPrefabs) {
				if (enemy.nameEnemyPrefab.ToString () == prefabInList.name)
					enemy.prefab = prefabInList.gameObject;
			}
		}
	}
}
