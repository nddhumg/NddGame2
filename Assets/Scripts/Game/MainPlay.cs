using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlay : NddBehaviour {
	[SerializeField] protected float timeScalePlay = 1f;
	[SerializeField] protected float timeScaleRunTime ;
	[SerializeField] protected bool isMobi ;

	public bool IsMobi{
		get{ 
			return isMobi;
		}
	}
	
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


	protected override void Awake(){
		base.Awake ();
		CheckIsMobi ();
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

	private void CheckIsMobi(){
		if (Application.platform == RuntimePlatform.Android) {
			isMobi = true;
		} else {
			isMobi = false;
		}
	}
}
