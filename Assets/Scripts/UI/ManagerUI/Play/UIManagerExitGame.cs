using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UIManagerExitGame : UIBehaviour {
	protected override void ResetValue ()
	{
		base.ResetValue ();
		startAppear = Vector3.zero;
		endAppear = new Vector3(1,1,1);
		speedAnimation = 0.2f;
	}
	protected override void Appear ()
	{
		rect.localScale = startAppear;
		Tween tween = rect.DOScale(endAppear,speedAnimation);
		tween.SetUpdate (true);
	}
	protected override void OnEnable ()
	{
		base.OnEnable ();
		UIManagerPlay.Instance.IsOpenUIExit = true;
	}
	void OnDisable(){
		UIManagerPlay.Instance.IsOpenUIExit = false;
	}
	public void OnClickYes(){
		SoundManager.Instance.OnPlaySound (SoundName.Click);
		UIManagerPlay.Instance.OpenUIEndGameLose ();
		gameObject.SetActive (false);
	}
	public void OnClickNo(){
		SoundManager.Instance.OnPlaySound (SoundName.Click);
		gameObject.SetActive (false);
	}
}
