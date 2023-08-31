using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyCtrl : NddBehaviour {
	
	[SerializeField] protected SpawnEnemy spawnEnemy;
	[SerializeField] protected SpawnEnemyPoint spawnEnemyPoint;
	[SerializeField] protected ManagerEnemySpawnByLevel managerEnemySpawnByLevel;
		
	public ManagerEnemySpawnByLevel ManagerEnemySpawnByLevel{
		get{
			return managerEnemySpawnByLevel;
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
		this.LoadManagerEnemySpawnByLevel ();
	}

	protected virtual void LoadManagerEnemySpawnByLevel(){
		if (this.managerEnemySpawnByLevel != null)
			return;
		this.managerEnemySpawnByLevel= GetComponentInChildren<ManagerEnemySpawnByLevel>();
		Debug.Log ("Add ManagerEnemySpawnByLevel", gameObject);
	}
	protected virtual void LoadSpawnEnemy(){
		if (this.spawnEnemy != null)
			return;
		this.spawnEnemy= transform.parent.GetComponent<SpawnEnemy>();
		Debug.Log ("Add SpawnEnemy", gameObject);
	}
	protected virtual void LoadSpawnEnemyPoint(){
		if (this.spawnEnemyPoint != null)
			return;
		this.spawnEnemyPoint= transform.parent.GetComponentInChildren<SpawnEnemyPoint>();
		Debug.Log ("Add SpawnEnemyPoint", gameObject);
	}


}
