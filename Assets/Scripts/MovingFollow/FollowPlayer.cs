using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : FollowTarget {
	protected override void LoadTarget ()
	{
		if (this.target != null)
			return;
		this.target = GameObject.Find ("Player").transform;
		Debug.Log ("Add Target: Player", gameObject);
	}
}
