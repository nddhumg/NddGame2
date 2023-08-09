using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerGame : NddBehaviour {
	[SerializeField] protected GameObject btnOpenSetting;
	[SerializeField] protected GameObject setting;
	[SerializeField] protected bool keyOpenSetting;

	public GameObject BtnOpenSetting{
		get{
			return btnOpenSetting;
		}
	}
	public GameObject Setting{
		get{
			return setting;
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
	protected override void Start () {
		base.Start ();
		setting.SetActive (false);
	}
	void Update(){
		keyOpenSetting = InputManager.Instance.KeyEsc;
		if (keyOpenSetting && !setting.activeSelf)
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
		if (this.setting != null)
			return;
		this.setting = GameObject.Find ("Setting");
		Debug.Log("Add UISetting",gameObject);
	}
	public virtual void OnClickOpenSetting(){
		SoundManager.Instance.OnPlaySound (SoundType.Click);
		Main.Instance.PauseGame ();
		setting.SetActive (true);
		btnOpenSetting.SetActive (false);
	}
}
