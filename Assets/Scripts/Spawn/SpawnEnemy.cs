using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : SpawnsPoolOgj {
	[SerializeField] protected float delaySpawn = 3f;
	[SerializeField] protected float timer =3f;
	[SerializeField] protected int numberSpawn =10 ;
	[SerializeField] protected int maxNumberSpawn = 200;
	[SerializeField] protected List<Transform> posSpawns;
	[SerializeField] protected bool isSpawnEnemy = true;
	[SerializeField] protected int numberOfEnemy = 0;
	[SerializeField] protected string enemy_1 = "Slime";

	private static SpawnEnemy instance;
	public static SpawnEnemy Instance{
		get{
			return instance;
		}
	}
	protected override void LoadSingleton() {
		if (SpawnEnemy.instance != null) {
			Debug.LogError("Only 1 SoawnEnemy allow to exist");
		}
		SpawnEnemy.instance = this;
	}

	protected override void Start(){
		base.Start ();
		StartCoroutine (CheckIsSpawnEnemy ());
	}
	void FixedUpdate(){
		this.DelaySpawnEnemy ();
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadPosSpawnEnemy ();
	}

	protected virtual void LoadPosSpawnEnemy(){
		if (posSpawns.Count > 0)
			return;
		Transform posSpawnEnemy = GameObject.Find ("PosSpawnEnemy").transform;
		foreach (Transform posEnemy in posSpawnEnemy) {
			posSpawns.Add (posEnemy);
		}
	}

	protected virtual void  DelaySpawnEnemy(){
		if (!isSpawnEnemy)
			return;
		timer += Time.fixedDeltaTime;
		if (timer < delaySpawn) {
			return;
		}
		int numberEnemySpawn = numberSpawn;
		if(maxNumberSpawn - numberOfEnemy < numberSpawn )
			numberEnemySpawn = maxNumberSpawn - numberOfEnemy;
		for (int i = 0; i < numberEnemySpawn; i++) {
			int randomPosSpawn = Random.Range (0, posSpawns.Count);
			Vector3 posSpawn = posSpawns [randomPosSpawn].position;
			Spawn (enemy_1, posSpawn, Quaternion.identity);
			numberOfEnemy++;
		}
		timer = 0;
	}
	IEnumerator CheckIsSpawnEnemy(){
		while (true) {
			CheckCoditionSpawn ();
			yield return new WaitForSeconds (1f);
		}
	}

	public virtual void ReductTheNumberofEnemy(){
		if (numberOfEnemy <= 0) {
			numberOfEnemy = 0;
			return;
		}
		numberOfEnemy--;
	}
	protected virtual void CheckCoditionSpawn(){
		if (numberOfEnemy >= maxNumberSpawn)
			isSpawnEnemy = false;
		else {
			isSpawnEnemy = true;
		}
	}	
}

