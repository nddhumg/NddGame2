using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelByTime : Level {
	[SerializeField] protected float timeLevelUp =1;

	protected virtual void FixedUpdate(){
		Levling ();
	}

	protected virtual void Levling(){
		if (InRunTime.Instance.TimeInMinutes <= timeLevelUp)
			return; 
		LevelUp ();
		timeLevelUp += InRunTime.Instance.TimeInMinutes;
	}

}
	