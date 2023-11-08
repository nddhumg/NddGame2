using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCircularPlayer : AbilityCircular  {

	protected override void ResetValue ()
	{
		base.ResetValue ();
		speed = 1.5f;
		maxPrefab = 5;
	}
	protected override void SetCenterPositionCircular ()
	{
		centerPosition = transform;
	}
}
