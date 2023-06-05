using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : SpawnsPoolOgj {
	[SerializeField] protected float delaySpawn = 1f;
	[SerializeField] protected Vector3 posRan;
	[SerializeField] protected Vector2 distance;
	[SerializeField] protected string enemy_1 = "Enemy1";


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
		distance = new Vector2 (4f,4f);
		StartCoroutine (DelaySpawn ());
	}

	private IEnumerator DelaySpawn(){
		
		yield return new WaitForSeconds(delaySpawn); 
		this.SpawnRandomPos ();
		yield return StartCoroutine(DelaySpawn());
	}
	protected virtual Transform SpawnRandomPos(){
		RandomPos ();
		Transform newEnemy = this.Spawn (enemy_1, posRan, Quaternion.identity);
		return newEnemy;
	}
	protected virtual void RandomPos(){
		Vector3 posPlayer = GameObjManager.Player.position ;

		posRan.x = Random.Range(posPlayer.x+ distance.x,posPlayer.x - distance.x );
		posRan.y = Random.Range(posPlayer.y+ distance.y,posPlayer.y - distance.y );
		posRan.z = 0;
	}

}

