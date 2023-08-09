using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : NddBehaviour {
	private static Main instance;
	public static Main Instance{
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
	public void PauseGame()
	{
		Time.timeScale = 0f; 
	}
	public void ResumeGame()
	{
		Time.timeScale = 1f; 
	}
}
