using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : SpawnsPoolOgj {
	[SerializeField] protected string bullet1 = "Bullet1";
	[SerializeField] protected string bullet2 = "Bullet2";

	public string  Bullet1{
		get{
			return bullet1;
		}
	}
	public string  Bullet2{
		get{
			return bullet2;
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
