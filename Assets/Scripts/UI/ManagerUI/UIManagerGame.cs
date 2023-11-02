﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerGame : NddBehaviour {
	[SerializeField] protected GameObject btnOpenSetting;
	[SerializeField] protected GameObject uiSetting;
	[SerializeField] protected GameObject uiEndGame;
	[SerializeField] protected bool keyOpenSetting;
	[SerializeField] protected bool isOpenUIGame;
	public GameObject BtnOpenSetting{
		get{
			return btnOpenSetting;
		}
	}
	public bool IsOpenUIGame{
		get{
			return isOpenUIGame;
		}
		set{
			isOpenUIGame = value;
		}
	}
	public GameObject UISetting{
		get{
			return uiSetting;
		}
	}
	private static UIManagerGame instance;
	public static UIManagerGame Instance{
		get{
			return instance;
		}
	}
	protected override void LoadSingleton() {
		if (UIManagerGame.instance != null) {
			Debug.LogError("Only 1 UIManagerGame allow to exist");

		}
		UIManagerGame.instance = this;
	}
	protected override void Start ()
	{
		base.Start ();
		DamageReceiverPlayer.OnDeadPlayer += OpenUIEndGameLose;
	}
	void Update(){
		keyOpenSetting = InputManager.Instance.KeyEsc;
		if (keyOpenSetting && !uiSetting.activeSelf)
			OnClickOpenSetting ();
		
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadBtnOpenSetting ();
		this.LoadUISetting ();
		LoadUIEndGame ();
	}
	protected virtual void LoadBtnOpenSetting(){
		if (this.btnOpenSetting != null)
			return;
		this.btnOpenSetting = GameObject.Find ("BtnOpenSetting");
		Debug.Log("Add BtnOpen",gameObject);
	}
	protected virtual void LoadUISetting(){
		if (this.uiSetting != null)
			return;
		this.uiSetting = GameObject.Find ("Setting");
		uiSetting.SetActive (false);
		Debug.Log("Add UISetting",gameObject);
	}
	protected virtual void LoadUIEndGame(){
		if (this.uiEndGame != null)
			return;
		this.uiEndGame = GameObject.Find ("UIEndGame");
		uiEndGame.SetActive (false);
		Debug.Log("Add UIEndGame",gameObject);
	}
	public virtual void OnClickOpenSetting(){
		SoundManager.Instance.OnPlaySound (SoundType.Click);
		MainPlay.Instance.PauseGame ();
		this.isOpenUIGame = true;
		uiSetting.SetActive (true);
	}
	private void OpenUIEndGameLose(){
		OpenUIEndGame ("Game Lose");
	}
	public void OpenUIEndGameWin(){
		OpenUIEndGame ("Win");
	}
	private void OpenUIEndGame(string status){
		uiEndGame.GetComponent<UIManagerEndGame>().TextStatusSetup(status);
		uiEndGame.SetActive (true);
	}
}
