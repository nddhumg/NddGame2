using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : FollowPlayer {
	protected override void ResetValue ()
	{
		base.ResetValue ();
		this.speedFollow = 2f;
	}

	protected override void Follow(){
		transform.parent.parent.position += direction * speedFollow * Time.deltaTime;
	}
}
