using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Level : NddBehaviour {
	[SerializeField] protected float levelCurrent = 0;
	[SerializeField] protected int levelMax = 99;
	public float LevelCurrent{
		get{
			return levelCurrent;
		}
	}
	public int LevelMax{
		get{
			return levelMax;
		}
	}
	public virtual void LevelUp(){
		levelCurrent++;
		this.LimitLevel ();	
	}
	public virtual void LevelUp(float expUp){
		levelCurrent += expUp;
		this.LimitLevel ();	
	}
	protected void LimitLevel(){
		if (levelCurrent > levelMax)
			levelCurrent = levelMax;
		if (levelCurrent < 0)
			levelCurrent = 0;
	}
	public virtual void LevelSet(int valueLevel){
		levelCurrent = valueLevel;
		this.LimitLevel ();
	}
	public virtual void LevelDown(){
		levelCurrent--;
		this.LimitLevel ();
	}
	public virtual void LevelDown(float expDown){
		levelCurrent -= expDown;
		this.LimitLevel ();	
	}
}

