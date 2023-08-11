using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerSetting : MonoBehaviour {

	public void OnClickExit(){
		SoundManager.Instance.OnPlaySound (SoundType.Click);
		LoadScene.Instance.LoadSceneByName (SceneName.GameStart);
	}
	public void OnClickCloseSetting(){
		SoundManager.Instance.OnPlaySound (SoundType.Click);
		UIManagerGame.Instance.BtnOpenSetting.SetActive (true);
		MainPlay.Instance.ResumeLastGame ();
		gameObject.SetActive (false);
	}
}
