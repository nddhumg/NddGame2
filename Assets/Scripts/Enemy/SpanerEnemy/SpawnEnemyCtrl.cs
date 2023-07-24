using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyCtrl : NddBehaviour {
	
	[SerializeField] protected SpawnEnemy spawnEnemy;
	[SerializeField] protected SpawnEnemyPoint spawnEnemyPoint;
	[SerializeField] protected ManagerRatioEnemyLevel managerRatioEnemyLevel;
	public ManagerRatioEnemyLevel ManagerRatioEnemyLevel{
		get{
			return managerRatioEnemyLevel;
		}
	}
	public SpawnEnemy SpawnEnemy{
		get{
			return spawnEnemy;
		}
	}
	public SpawnEnemyPoint SpawnEnemyPoint{
		get{
			return spawnEnemyPoint;
		}
	}

	protected override void LoadComponent(){
		this.LoadSpawnEnemy ();
		this.LoadSpawnEnemyPoint ();
		this.LoadManagerRatioEnemyLevel ();
	}
	protected virtual void LoadManagerRatioEnemyLevel(){
		if (this.managerRatioEnemyLevel != null)
			return;
		this.managerRatioEnemyLevel= GetComponentInChildren<ManagerRatioEnemyLevel>();
		Debug.Log ("Add ManagerRatioEnemyLevel", gameObject);
	}
	protected virtual void LoadSpawnEnemy(){
		if (this.spawnEnemy != null)
			return;
		this.spawnEnemy= GetComponent<SpawnEnemy>();
		Debug.Log ("Add SpawnEnemy", gameObject);
	}
	protected virtual void LoadSpawnEnemyPoint(){
		if (this.spawnEnemyPoint != null)
			return;
		this.spawnEnemyPoint= GetComponent<SpawnEnemyPoint>();
		Debug.Log ("Add SpawnEnemyPoint", gameObject);
	}


}
