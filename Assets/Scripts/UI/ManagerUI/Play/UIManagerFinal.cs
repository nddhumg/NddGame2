using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UIManagerFinal : UIBehaviour {
	[SerializeField] private GameObject UIEndGame;
	protected override void OnEnable(){
		base.OnEnable ();
		MainPlay.Instance.PauseGame ();
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
		UIEndGame.SetActive (true);
		UIEndGame.GetComponent<UIManagerEndGame> ().Win();
	}
}
