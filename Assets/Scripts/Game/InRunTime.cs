using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRunTime : NddBehaviour {
	[SerializeField]private float timer = 0;
	[SerializeField]private float timeInMinutes;
	private static InRunTime instance;
	public static InRunTime Instance{
		get{
			return instance;
		}
	}
	protected override void LoadSingleton() {
		if (InRunTime.instance != null) {
			Debug.LogError("Only 1 LevelMap allow to exist");

		}
		InRunTime.instance = this;
	}

	public  float Timer{
		get{
			return timer;
		}
	}
	public float TimeInMinutes{
		get{
			return timeInMinutes;
		}
	}

	void FixedUpdate () {
		timer += Time.fixedDeltaTime;
		this.SwapTimeMinutes ();
	}
	protected void SwapTimeMinutes(){
		timeInMinutes = timer/60f;
	}
	public virtual string ChangeTimerToString(float timer){
		int  minutes, seconds;
		minutes = (int)((timer % 3600) / 60);
		seconds = (int)(timer % 60);
		return minutes.ToString() + ":" + seconds.ToString();
	}
}
