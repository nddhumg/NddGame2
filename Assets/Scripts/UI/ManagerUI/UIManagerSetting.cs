using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerSetting : NddBehaviour {
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
	}

	void OnEnable(){
		UIManagerGame.Instance.BtnOpenSetting.SetActive (false);
	}
	void OnDisable(){
		UIManagerGame.Instance.BtnOpenSetting.SetActive (true);
	}
	void Update(){
		bool keyOpenSetting = InputManager.Instance.KeyEsc;
		if (keyOpenSetting && gameObject.activeSelf)
			OnClickCloseSetting ();
	}
	public void OnClickExit(){
		SoundManager.Instance.OnPlaySound (SoundType.Click);
		UIManagerGame.Instance.UiExitGame.SetActive (true);
	}
	public void OnClickCloseSetting(){
		SoundManager.Instance.OnPlaySound (SoundType.Click);
		UIManagerGame.Instance.IsOpenUIGame = false;
		MainPlay.Instance.ResumeLastGame ();
		gameObject.SetActive (false);
	}
}
