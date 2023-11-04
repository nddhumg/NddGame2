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
