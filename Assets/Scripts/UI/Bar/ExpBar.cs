using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpBar : BarUI {
	protected override void GetValue(){
		valueCurrent = LevelPlayer.Instance.ExpCurrent;
		valueMax =  LevelPlayer.Instance.ExpLevelUp;
	}
	
}
