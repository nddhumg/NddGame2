using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlay : NddBehaviour {
	[SerializeField]protected float timeScalePlay = 1f;
	[SerializeField]protected float timeScaleRunTime ;

	//Debug
	[SerializeField] protected float currentTimeScale;
	public bool debug;
	//
	private static MainPlay instance;
	public static MainPlay Instance{
		get{
			return instance;
		}
	}
	protected override void LoadSingleton() {
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	protected override void Start ()
	{
		base.Start (); 
		timeScaleRunTime = timeScalePlay;
		DamageReceiverPlayer.OnDeadEvent += PauseGame;
	}
	public void PauseGame()
	{
		timeScaleRunTime = Time.timeScale;
		Time.timeScale = 0f;
	}
	public void ResumeGame()
	{
		timeScaleRunTime = Time.timeScale;
		Time.timeScale = timeScalePlay; 
	}

	public void ResumeLastGame()
	{
		Time.timeScale = timeScaleRunTime; 
	}
}
