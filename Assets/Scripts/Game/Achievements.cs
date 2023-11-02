using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : NddBehaviour {
	private static Achievements instance;
	public static Achievements Instance{
		get{
			return instance;
		}
	}

	protected override void LoadSingleton() {
		if (Achievements.instance != null) {
			Debug.LogError ("Only 1 SpawnFx allow to exist");
		}
		Achievements.instance = this;
	}

	public int enemyKill = 0;

}
