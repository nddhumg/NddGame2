using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTimeGame : TextBase {
	void FixedUpdate(){
		this.SetTextTimeGame ();
	}
	protected override void Reset(){
		base.Reset ();
		this.SetProptiesTxTimeGame ();
	}
	protected virtual void SetProptiesTxTimeGame(){
		text.fontStyle = FontStyle.Bold;
		text.fontSize = 16;
		text.alignment = TextAnchor.MiddleCenter;
	}
	protected virtual void SetTextTimeGame(){
		text.text = InRunTime.Instance.ChangeTimerToString(InRunTime.Instance.Timer);
	}
}
