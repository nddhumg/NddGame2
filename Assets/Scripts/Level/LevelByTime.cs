using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelByTime : Level {
	[SerializeField] protected float timeLevelUpByMinutes =1;

	protected virtual void FixedUpdate(){
		Levling ();
	}

	protected virtual void Levling(){
		if (InRunTime.Instance.TimeInMinutes <= timeLevelUpByMinutes)
			return; 
		if (IsMaxLevel ())
			return;
		LevelUp ();
		timeLevelUpByMinutes += InRunTime.Instance.TimeInMinutes;
	}
	protected bool IsMaxLevel(){
		return levelCurrent >= levelMax;
	}
}
	