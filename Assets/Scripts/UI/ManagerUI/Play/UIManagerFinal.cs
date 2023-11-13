using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UIManagerFinal : UIBehaviour {
	protected override void OnEnable(){
		base.OnEnable ();
//		MainPlay.Instance.PauseGame ();
//		UIManagerPlay.Instance.BtnOpenSetting.SetActive (false);
	}
	protected override void ResetValue ()
	{
		startAppear = Vector3.zero;
		endAppear = Vector3.one;
	}
	protected override void Appear ()
	{
		rect.localScale = startAppear;
		Tween tween = rect.DOScale(endAppear,speedAnimation);
		tween.SetUpdate (true);
	}
	public void OnClickYes(){
		gameObject.SetActive (false);
		MainPlay.Instance.ResumeGame ();
	}

	public void OnClickNo(){
		gameObject.SetActive (false);
		UIManagerPlay.Instance.OpenUIEndGameWin ();
	}
}
