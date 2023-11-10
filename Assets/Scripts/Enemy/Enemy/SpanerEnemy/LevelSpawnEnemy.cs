using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawnEnemy : LevelByTime {
	private static LevelSpawnEnemy instance;
	public static LevelSpawnEnemy Instance{
		get{
			return instance;
		}
	}
	protected override void LoadSingleton() {
		if (LevelSpawnEnemy.instance != null) {
			Debug.LogError("Only 1 LevelMap allow to exist");

		}
		LevelSpawnEnemy.instance = this;
	}

	protected override void ResetValue ()
	{
		base.ResetValue ();
		levelMax = 5;
	}
	public override void LevelUp ()
	{
		base.LevelUp ();
		SpawnEnemy.Instance.TakeArrayEnemyByLevel ((int)levelCurrent);
	}
}

