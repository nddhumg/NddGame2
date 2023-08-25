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
		text.text = ChangeTimerToString(InRunTime.Instance.Timer);
	}
	protected virtual string ChangeTimerToString(float timer){
		int  minutes, seconds;
		minutes = (int)((timer % 3600) / 60);
		seconds = (int)(timer % 60);
		return minutes.ToString() + ":" + seconds.ToString();
	}
}
