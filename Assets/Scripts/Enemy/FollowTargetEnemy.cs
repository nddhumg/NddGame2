using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetEnemy : FollowTarget {
	protected override void ResetValue ()
	{
		base.ResetValue ();
		this.speedFollow = 4;
	}
	protected override void LoadTarget ()
	{
		if (this.target != null)
			return;
		
		this.target = GameObjManager.Player;
		Debug.Log ("Add Target: Player", gameObject);
	}
	protected override void Follow(){
		if (target == null) {
			Debug.LogError ("Not Obj Target",gameObject);
			return;
		}
		transform.parent.position = Vector3.Lerp (transform.position, this.target.position, this.speedFollow * Time.deltaTime);
	}
}
