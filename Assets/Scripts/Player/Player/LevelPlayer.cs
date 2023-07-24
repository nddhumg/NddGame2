using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPlayer : Level {
	private static LevelPlayer instance;
	public static LevelPlayer Instance{
		get{
			return instance;
		}
	}
	protected override void LoadSingleton() {
		if (LevelPlayer.instance != null) {
			Debug.LogError("Only 1 LevelPlayer allow to exist");

		}
		LevelPlayer.instance = this;
	}
}
