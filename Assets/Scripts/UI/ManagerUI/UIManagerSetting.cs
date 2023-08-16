using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerSetting : MonoBehaviour {
	
	void Update(){
		bool keyOpenSetting = InputManager.Instance.KeyEsc;
		if (keyOpenSetting && gameObject.activeSelf)
			OnClickCloseSetting ();
	}
	public void OnClickExit(){
		SoundManager.Instance.OnPlaySound (SoundType.Click);
		LoadScene.Instance.LoadSceneByName (SceneName.GameStart);
	}
	public void OnClickCloseSetting(){
		SoundManager.Instance.OnPlaySound (SoundType.Click);
		UIManagerGame.Instance.BtnOpenSetting.SetActive (true);
		UIManagerGame.Instance.IsOpenUIGame = false;
		MainPlay.Instance.ResumeLastGame ();
		gameObject.SetActive (false);
	}
}
