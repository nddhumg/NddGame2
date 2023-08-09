using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSound : SpawnsPoolOgj {

	private static SpawnSound instance;
	public static SpawnSound Instance{
		get{
			return instance;
		}
	}

	protected override void LoadSingleton() {
		if (SpawnSound.instance != null) {
			Debug.LogError ("Only 1 SpawnSound allow to exist");
		}
		SpawnSound.instance = this;
	}
}
