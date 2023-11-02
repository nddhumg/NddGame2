using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerExitGame : NddBehaviour {
	public void OnClickYes(){
		SoundManager.Instance.OnPlaySound (SoundType.Click);
		UIManagerGame.Instance.OpenUIEndGameLose ();
		gameObject.SetActive (false);
	}
	public void OnClickNo(){
		SoundManager.Instance.OnPlaySound (SoundType.Click);
		gameObject.SetActive (false);
	}
}
