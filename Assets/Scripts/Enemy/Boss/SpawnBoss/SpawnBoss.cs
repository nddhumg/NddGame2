using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : SpawnsPoolOgj {
	[Header("Boss Spawn")]
	[SerializeField] protected float delayMinutesSpawn = 5f;
	[SerializeField] protected float timerMinutesSpawn = 5f;
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
	IEnumerator Delay1Second(){
		while (true) {
			this.SpawnDelay ();
			yield return new WaitForSeconds (1f);
		}
	}
	protected virtual void SpawnDelay(){
		if (InRunTime.Instance.TimeInMinutes < timerMinutesSpawn)
			return;
		Spawn (EnemyName.SlimeBoss.ToString (), SpawnEnemyPoint.Instance.GetRandomPoinSpawn ().position, Quaternion.identity);
		timerMinutesSpawn += delayMinutesSpawn;
	}
}
