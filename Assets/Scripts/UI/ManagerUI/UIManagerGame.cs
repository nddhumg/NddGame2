using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerGame : NddBehaviour {
	[SerializeField] protected GameObject btnOpenSetting;
	[SerializeField] protected GameObject uiSetting;
	[SerializeField] protected bool keyOpenSetting;
	[SerializeField] protected bool isOpenUIGame  ;
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
	public virtual void OnClickOpenSetting(){
		SoundManager.Instance.OnPlaySound (SoundType.Click);
		MainPlay.Instance.PauseGame ();
		this.isOpenUIGame = true;
		uiSetting.SetActive (true);
		btnOpenSetting.SetActive (false);
	}
}
