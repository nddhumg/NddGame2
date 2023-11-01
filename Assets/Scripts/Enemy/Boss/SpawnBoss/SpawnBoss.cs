using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnBoss : SpawnsPoolOgj {
	[Header("Boss Spawn")]

	[SerializeField] protected float delayMinutesSpawn = 5f;
	[SerializeField] protected float timerMinutesSpawn = 5f;
	[SerializeField] protected EnemyName[] arrayBoss;
	[SerializeField] protected SOArrayBoss SOArrayBoss;
	private int bossNumber = 0;
	private static SpawnBoss instance;
	public static SpawnBoss Instance{
		get{
			return instance;
		}
	}
	protected override void Start ()
	{
		base.Start ();
		StartCoroutine (Delay1Second());
	}
	protected override void LoadSingleton() {
		if (SpawnBoss.instance != null) {
			Debug.LogError ("Only 1 SpawnBoss allow to exist");
		}
		SpawnBoss.instance = this;
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadSOArrayBoss ();
		LoadArrayBoss ();
	}
	protected virtual void LoadArrayBoss(){
		if (arrayBoss.Length > 0)
			return;
		if (SOArrayBoss == null) {
			Debug.LogError ("Null SO", gameObject);
			return;
		}
		arrayBoss = SOArrayBoss.bossName;
		Debug.LogWarning ("Add ArrayBoss", gameObject);
	}
	protected virtual void LoadSOArrayBoss(){
		if (SOArrayBoss != null)
			return;
		string resPath = "ScriptableObject/Spawn/Boss/" + "SpawnBoss";
		SOArrayBoss = Resources.Load<SOArrayBoss> (resPath);
		Debug.LogWarning ("Add SO ArrayBoss", gameObject);
	}
	IEnumerator Delay1Second(){
		while (true) {
			this.SpawnDelay ();
			yield return new WaitForSeconds (1f);
		}
	}
	protected virtual void SpawnDelay(){ 
		if (InRunTime.Instance.TimeInMinutes < timerMinutesSpawn)
			return;
		Spawn (GetNameBossSpawn(), SpawnEnemyPoint.Instance.GetRandomPoinSpawn ().position, Quaternion.identity);
		bossNumber++;
		timerMinutesSpawn += delayMinutesSpawn;
	}
	protected virtual string GetNameBossSpawn(){
		string nameBoss = null;
		try{
		nameBoss = arrayBoss[bossNumber].ToString();
		}
		catch
		{
			StopCoroutine(Delay1Second());
			Debug.Log ("Stop Spawn Boss",gameObject);
		}
		return nameBoss;	
	}
}
