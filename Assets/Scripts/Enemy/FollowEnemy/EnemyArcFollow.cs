using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcFollow : EnemyFollow {
	[Header("EnemyArcFollow")]
	[SerializeField] protected float distanceStopFollow = 15;
	[SerializeField] protected float distanceFromPlayer;
		
	protected override void ChangeIsFollowing(){
		distanceFromPlayer = Vector3.Distance (transform.position, target.position);
		if (distanceFromPlayer > distanceStopFollow) {
			isFollowing = true;
		} else {
			isFollowing = false;
		}
	}
}
