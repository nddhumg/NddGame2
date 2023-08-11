using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlay : NddBehaviour {
	[SerializeField]protected float timeScalePlay = 1f;
	[SerializeField]protected float timeScaleRunTime ;
	private static MainPlay instance;
	public static MainPlay Instance{
		get{
			return instance;
		}
	}
	protected override void Start ()
	{
		base.Start ();
		timeScaleRunTime = timeScalePlay;
	}
	protected override void LoadSingleton() {
		if (MainPlay.instance != null) {
			Debug.LogError("Only 1 Main allow to exist");

		}
		MainPlay.instance = this;
	}
	public void PauseGame()
	{
		Time.timeScale = 0f;
		timeScaleRunTime = 0f;
	}
	public void ResumeGame()
	{
		Time.timeScale = timeScalePlay; 
		timeScaleRunTime = timeScalePlay;
	}

	public void ResumeLastGame()
	{
		Time.timeScale = timeScaleRunTime; 
	}
}
