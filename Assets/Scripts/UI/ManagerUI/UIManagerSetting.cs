using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UIManagerSetting : UIBehaviour {
	protected override void ResetValue ()
	{
		base.ResetValue ();
		speedAnimation = 0.3f;
	}
	protected override void OnEnable(){
		base.OnEnable ();
		UIManagerGame.Instance.BtnOpenSetting.SetActive (false);
	}
	void OnDisable(){
		UIManagerGame.Instance.BtnOpenSetting.SetActive (true);
	}
	void FixedUpdate(){
		bool keyOpenSetting = InputManager.Instance.KeyEsc;
		if (keyOpenSetting && gameObject.activeSelf)
			OnClickCloseSetting ();
	}
	protected override void Appear(){
		transform.localPosition = startAppear;
		Tween tween = rect.DOAnchorPos (endAppear, speedAnimation, false);
		tween.SetUpdate (true);
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
