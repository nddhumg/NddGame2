using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : SpawnPool {
	private static SpawnItem instance;
	public static SpawnItem Instance{
		get{
			return instance;
		}
	}

	protected override void LoadSingleton() {
		if (SpawnItem.instance != null) {
			Debug.LogError ("Only 1 SpawnPotions allow to exist");
		}
		SpawnItem.instance = this;
	}
}
