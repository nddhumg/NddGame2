using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnExp : SpawnsPoolOgj {
	private static SpawnExp instance;
	public static SpawnExp Instance{
		get{
			return instance;
		}
	}

	protected override void LoadSingleton() {
		if (SpawnExp.instance != null) {
			Debug.LogError ("Only 1 SpawnerExp allow to exist");
		}
		SpawnExp.instance = this;
	}
}
