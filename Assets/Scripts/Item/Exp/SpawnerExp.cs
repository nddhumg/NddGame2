using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerExp : SpawnsPoolOgj {
	private static SpawnerExp instance;
	public static SpawnerExp Instance{
		get{
			return instance;
		}
	}

	protected override void LoadSingleton() {
		if (SpawnerExp.instance != null) {
			Debug.LogError ("Only 1 SpawnerExp allow to exist");
		}
		SpawnerExp.instance = this;
	}
}
