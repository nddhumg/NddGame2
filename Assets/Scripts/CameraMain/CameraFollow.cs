using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : FollowTarget {
	protected override void ResetValue ()
	{
		base.ResetValue ();
	
	}
	protected override void LoadTarget(){
		if (this.target != null)
			return;
		this.target = GameObjManager.Player;
		Debug.Log ("Add Target: Player" , gameObject);
	}

}
