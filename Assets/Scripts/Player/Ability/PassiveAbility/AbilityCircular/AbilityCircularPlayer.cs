using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCircularPlayer : AbilityCircular  {

	protected override void ResetValue ()
	{
		base.ResetValue ();
		speed = 1f;
		maxPrefab = 5;
	}
	protected override void LoadCenterPositionCircular ()
	{
		if (centerPosition != null)
			return;
		centerPosition = transform;
		Debug.LogWarning ("Add centerPosition", gameObject);
	}
}
