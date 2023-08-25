using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : SpawnsPoolOgj {
	private static SpawnBoss instance;
	public static SpawnBoss Instance{
		get{
			return instance;
		}
	}

	protected override void LoadSingleton() {
		if (SpawnBoss.instance != null) {
			Debug.LogError ("Only 1 SpawnBoss allow to exist");
		}
		SpawnBoss.instance = this;
	}
}
