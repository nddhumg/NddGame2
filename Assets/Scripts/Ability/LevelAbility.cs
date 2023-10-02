using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class LevelAbility : Level {
	protected override void ResetValue ()
	{
		base.ResetValue ();
		levelMax = 10;
	}
	public abstract void LevelAbilityUp();
}
