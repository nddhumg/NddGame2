using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLevelUp : DebugGame {
	public virtual void LevelUp(){
		LevelPlayer.Instance.LevelUp ();

	}
	protected override void StartDebug ()
	{
		LevelUp ();
	}
}
