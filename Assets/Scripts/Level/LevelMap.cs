using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMap : LevelByTime {
	private static LevelMap instance;
	public static LevelMap Instance{
		get{
			return instance;
		}
	}
	protected override void LoadSingleton() {
		if (LevelMap.instance != null) {
			Debug.LogError("Only 1 LevelMap allow to exist");

		}
		LevelMap.instance = this;
	}

	protected override void ResetValue ()
	{
		base.ResetValue ();
		levelMax = 5;
	}
}
