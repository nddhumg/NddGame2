using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerPlay : NddBehaviour {
	[Header("UI")]
	[SerializeField] private GameObject btnOpenSetting;
	[SerializeField] private GameObject uiSetting;
	[SerializeField] private GameObject uiEndGame;
	[SerializeField] private GameObject uiExitGame;
	[SerializeField] private GameObject uiFinal;

	[Header("UI Status")]
	[SerializeField] private bool keyOpenSetting;

	[SerializeField] private bool isOpenUISetting;
	[SerializeField] private bool isOpenUIExit;

	public bool IsOpenUIExit{
		get{
			return isOpenUIExit;
		}
		set{
			isOpenUIExit = value;
		}
	}
	public bool IsOpenUISetting{
		get{
			return isOpenUISetting;
		}
		set{
			isOpenUISetting = value;
		}
	}

	public GameObject BtnOpenSetting {
		get {
			return btnOpenSetting;
		}
	}
	public GameObject UISettingget {
		get {
			return uiSetting;
		}
	}
	public GameObject UIFinal {
		get {
			return uiFinal;
		}
	}
	public GameObject UiExitGame{
		get {
			return uiExitGame;
		}
	}

	private static UIManagerPlay instance;
	public static UIManagerPlay Instance{
		get {
			return instance;
		}
	}
	protected override void LoadSingleton() {
		if (UIManagerPlay.instance != null) {
			Debug.LogError("Only 1 UIManagerGame allow to exist");

		}
		UIManagerPlay.instance = this;
	}
	protected override void Start ()
	{
		base.Start ();
		DamageReceiverPlayer.OnDeadEvent += OpenUIEndGameLose;
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
	}
	protected virtual void LoadBtnOpenSetting(){
		if (this.btnOpenSetting != null)
			return;
		this.btnOpenSetting = GameObject.Find ("BtnOpenSetting");
		Debug.Log("Add BtnOpen",gameObject);
	}
	public virtual void OnClickOpenSetting(){
		SoundManager.Instance.OnPlaySound (SoundName.Click);
		MainPlay.Instance.PauseGame ();
		this.isOpenUISetting = true;
		uiSetting.SetActive (true);
	}
	public void OpenUIEndGameLose(){
		uiEndGame.SetActive (true);
		uiEndGame.GetComponent<UIManagerEndGame>().Lose();
	}
	public void OpenUIEndGameWin(){
		uiEndGame.SetActive (true);
		uiEndGame.GetComponent<UIManagerEndGame>().Win();
	}
}
