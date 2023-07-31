using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextLevel : BaseText {
	[SerializeField]protected string stringLevel = "Level";
	protected int GetLevelPlayer(){
		return (int)LevelPlayer.Instance.LevelCurrent;
	}
	protected void SetTextLevel(){
		text.text = stringLevel + ": " + GetLevelPlayer ();
	}
	protected virtual void FixedUpdate(){
		SetTextLevel ();
	}
}
