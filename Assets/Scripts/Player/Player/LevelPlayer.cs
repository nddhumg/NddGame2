using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPlayer : Level {
	[SerializeField] protected float expCurrent = 0;
	[SerializeField] protected float expLevelUp = 20;
	[SerializeField] protected float expLevelUpIncreaseRate = 0.5f;
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

	public virtual void IncreaseExp(float exp){
		expCurrent += exp;
		LevelUpByExp ();
	}
	protected virtual void LevelUpByExp(){
		if (expCurrent <= expLevelUp)
			return;
		expCurrent -= expLevelUp;
		LevelUp ();
		IncreaseExpLevelup ();
		Transform fxLevelUpNew = SpawnFx.Instance.Spawn (SpawnFx.Instance.FxLevelUp, transform.position + new Vector3(0f,1f,0f), Quaternion.identity);
		fxLevelUpNew.parent = transform.parent;
	}
	protected virtual void IncreaseExpLevelup(){
		expLevelUp += expLevelUpIncreaseRate*expLevelUp;
	}
}
