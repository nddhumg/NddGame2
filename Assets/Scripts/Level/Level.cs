using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Level : NddBehaviour {
	[SerializeField] protected float levelCurrent = 1;
	[SerializeField] protected int levelMax = 99;
	[SerializeField] protected int levelMin = 0;
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
	public virtual void LevelUp(float valueLevelUp){
		levelCurrent += valueLevelUp;
		this.LimitLevel ();	
	}
	protected void LimitLevel(){
		if (levelCurrent > levelMax)
			levelCurrent = levelMax;
		if (levelCurrent < levelMin)
			levelCurrent = levelMin;
	}
	public virtual void LevelSet(float valueLevelSet){
		levelCurrent = valueLevelSet;
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

