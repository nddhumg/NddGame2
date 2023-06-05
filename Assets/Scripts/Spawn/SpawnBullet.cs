using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : SpawnsPoolOgj {
	
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
