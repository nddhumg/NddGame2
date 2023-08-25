using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : SpawnsPoolOgj {
	[SerializeField] protected string bulletDragonPiercing = "BulletDragonPiercing";
	[SerializeField] protected string bulletDragonNormal = "BulletDragonNormal";
	[SerializeField] protected string bulletGoblinKing = "BulletGoblinKing";
	public string  BulletDragonPiercing{
		get{
			return bulletDragonPiercing;
		}
	}
	public string  BulletDragonNormal{
		get{
			return bulletDragonNormal;
		}
	}
	public string  BulletGoblinKing{
		get{
			return bulletGoblinKing;
		}
	}
	private static SpawnBullet instance;
	public static SpawnBullet Instance{
		get{
			return instance;
		}
	}
		
	protected override void LoadSingleton() {
		if (SpawnBullet.instance != null) {
			Debug.LogError("Only 1 SpawnBullet allow to exist");
		}
		SpawnBullet.instance = this;
	}	

}
