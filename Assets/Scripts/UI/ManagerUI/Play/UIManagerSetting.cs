using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class UIManagerSetting : UIBehaviour {
	protected override void ResetValue ()
	{
		base.ResetValue ();
		speedAnimation = 0.3f;
	}
	protected override void OnEnable(){
		base.OnEnable ();
		UIManagerPlay.Instance.BtnOpenSetting.SetActive (false);
	}
	void OnDisable(){
		UIManagerPlay.Instance.BtnOpenSetting.SetActive (true);
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
		if (UIManagerPlay.Instance.IsOpenUIExit) {
			return;
		}
		SoundManager.Instance.OnPlaySound (SoundName.Click);
		UIManagerPlay.Instance.UiExitGame.SetActive (true);

	}
	public void OnClickCloseSetting(){
		if (UIManagerPlay.Instance.IsOpenUIExit) {
			return;
		}
		SoundManager.Instance.OnPlaySound (SoundName.Click);
		UIManagerPlay.Instance.IsOpenUISetting = false;
		MainPlay.Instance.ResumeLastGame ();
		gameObject.SetActive (false);
	}
	public void ToggleMusic(){
		MusicManager.Instance.Toggle ();
	}
	public void ToggleSound(){
		SoundManager.Instance.Toggle ();
	}
}
