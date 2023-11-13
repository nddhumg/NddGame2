using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class UIManagerOption : UIBehaviour {
	protected override void Appear ()
	{
		transform.localPosition = startAppear;
		Tween tween = rect.DOAnchorPos (endAppear, speedAnimation, false).SetEase(Ease.OutBounce);
		tween.SetUpdate (true);
	}
	public void OnClickCloseUI(){
		gameObject.SetActive (false);
	}
}
