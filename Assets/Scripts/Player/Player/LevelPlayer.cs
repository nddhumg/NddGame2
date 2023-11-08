using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPlayer : Level {
	[SerializeField] protected float expCurrent = 0;
	[SerializeField] protected float expLevelUp = 20;
	[SerializeField] protected float expLevelUpIncreaseRate = 0.2f;
	public float ExpCurrent{
		get{
			return expCurrent;
		}
	}
	public float ExpLevelUp{
		get{
			return expLevelUp;
		}
	}
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
		Transform fxLevelUpNew = SpawnFx.Instance.Spawn (FxName.FxLevelUp.ToString(), transform.position + new Vector3(0f,1f,0f), Quaternion.identity);
		fxLevelUpNew.parent = transform.parent;
	}
	public override void LevelUp ()
	{
		base.LevelUp ();
		EnhancementCreateManager.Instance.CreateCard ();
		SoundManager.Instance.OnPlaySound (SoundType.LevelUp);
	}
	protected virtual void IncreaseExpLevelup(){
		expLevelUp += expLevelUpIncreaseRate*expLevelUp;
	}
}
