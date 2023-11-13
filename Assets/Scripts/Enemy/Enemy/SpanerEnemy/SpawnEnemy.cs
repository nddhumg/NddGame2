using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : SpawnsPoolOgj {
	private static SpawnEnemy instance;
	public static SpawnEnemy Instance{
		get{
			return instance;
		}
	}

	protected override void LoadSingleton() {
		if (SpawnEnemy.instance != null) {
			Debug.LogError ("Only 1 SpawnFx allow to exist");
		}
		SpawnEnemy.instance = this;
	}
	[Header("LimitSpawn")]
	[SerializeField] private int numberOfEnemy = 0;
	[SerializeField] private int numberOfEnemyArc = 0;
	[SerializeField] private int maxNumberEnemyArc = 6;
	[SerializeField] private int maxNumberSpawn = 200;

	[Header("dataSpawn")]
	[SerializeField] private int numberSpawn = 10;
	[SerializeField] private float delaySpawn = 3f;
	[SerializeField] private LevelSpawnEnemy levelSpawnEnemy;
	[SerializeField] private  EnemySpawnRate[] arrEnemySpawn; 
	private float overallSpawnRate = 0;

	protected override void Start ()
	{
		base.Start ();
		StartCoroutine (DelaySpawn());
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadLevelSpawn ();
	}
	protected virtual void LoadLevelSpawn(){
		if (levelSpawnEnemy != null)
			return;
		levelSpawnEnemy = transform.GetComponentInChildren<LevelSpawnEnemy> ();
		if (levelSpawnEnemy != null)
			TakeArrayEnemyByLevel ((int)levelSpawnEnemy.LevelCurrent);

	}
	IEnumerator  DelaySpawn(){
		while (true) {
			if (CanSpawn ()) {
				SpawnByTurn ();
			}
			yield return new WaitForSeconds (delaySpawn);
		}
	}
	protected virtual void SpawnByTurn()
	{
		int numberEnemySpawn = numberSpawn;
		if (maxNumberSpawn - numberOfEnemy < numberSpawn) {
			numberEnemySpawn = maxNumberSpawn - numberOfEnemy;
		}
		for (int i = 0; i < numberEnemySpawn; i++) {
			SpawnByLevel();
		}
	}
	protected virtual void SpawnByLevel(){
		Vector3 posSpawn = SpawnEnemyPoint.Instance.GetRandomPoinSpawn().position;
		int levelCurrent = (int)levelSpawnEnemy.LevelCurrent;
		string prefabNameSpawn = GetRandomNameEnemyByLevel ();
		if (prefabNameSpawn == null) {
			Debug.LogWarning ("Dont enemy spawn in level" + levelCurrent, gameObject);
			return;
		}
		if (prefabNameSpawn == EnemyName.GoblinKing.ToString ()) {
			if (!CanSpawnEnemyArc()) {
				return;
			}
			numberOfEnemyArc++;
		}
		Spawn (prefabNameSpawn,posSpawn,Quaternion.identity);
		numberOfEnemy++;
	}
	private string GetRandomNameEnemyByLevel(){
		float ran = Random.Range (0f, 1f);
		float temp = 0;

		foreach (EnemySpawnRate enemySpawn in arrEnemySpawn) {
			temp += (enemySpawn.percentage / overallSpawnRate);
			if (ran <= temp) {
				return enemySpawn.nameEnemyPrefab.ToString ();
			}
		}
		return null;
	}
	private void TakeOverallSpawnRate(){
		overallSpawnRate = 0;
		if (arrEnemySpawn.Length <= 0) {
			return;
		}
		foreach (EnemySpawnRate enemySpawn in arrEnemySpawn) {
			this.overallSpawnRate += enemySpawn.percentage;
		}
	}
	public void TakeArrayEnemyByLevel(int levelCurrent){
		string resPath = "ScriptableObject/Spawn/Enemy/" + "SpawnEnemyByLevel" + levelCurrent;
		SpawnEnemyByLevelSO spawnEnemyByLevelSO = Resources.Load<SpawnEnemyByLevelSO> (resPath);
		if (spawnEnemyByLevelSO == null) {
			Debug.LogWarning ("Dont take spawn enemy so", gameObject);
			return;
		}
		arrEnemySpawn = spawnEnemyByLevelSO.ArrEnemySpawn;
		TakeOverallSpawnRate();
	}
	public  void ReductTheNumberofEnemyArc(){
		if (numberOfEnemyArc <= 0) {
			numberOfEnemyArc = 0;
			return;
		}
		numberOfEnemyArc--;
	}
	private void ReductTheNumberofEnemy(){
		if (numberOfEnemy <= 0) {
			numberOfEnemy = 0;
			return;
		}
		numberOfEnemy--;
	}
	public override void DesTroyPrefabs(Transform obj){
		ReductTheNumberofEnemy ();
		base.DesTroyPrefabs (obj);
	}
	private bool CanSpawn(){
		return numberOfEnemy < maxNumberSpawn;
	}
	private bool CanSpawnEnemyArc(){
		return numberOfEnemyArc < maxNumberEnemyArc;
	}
}
