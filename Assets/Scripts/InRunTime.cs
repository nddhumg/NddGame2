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

	void Update () {
		timer += Time.deltaTime;
		this.SwapTimeMinutes ();
	}
	protected void SwapTimeMinutes(){
		timeInMinutes = timer/60f;
	}
}
