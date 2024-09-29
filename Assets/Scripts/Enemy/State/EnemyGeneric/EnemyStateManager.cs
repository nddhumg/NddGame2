using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : StateManager {
	[SerializeField]protected SOMove dataMove;
	[SerializeField]protected SOBaseEnemy dataEnemy;
	[SerializeField]protected Rigidbody2D rig;
	public Vector3 temp; 
	public float temp2;
	protected override void FixedUpdate ()
	{
		base.FixedUpdate ();
		rig.velocity = Vector2.zero;
	}
	public virtual void Flip(){
		if (Player.Instance.GetPosition ().x > transform.position.x)
			transform.parent.parent.localScale= new Vector3 (1f, 1f, 1f);
		else			
			transform.parent.parent.localScale= new Vector3 (-1f, 1f, 1f);
	}
	public virtual void FolowingPlayer(){
		Flip ();
		Vector3 playerPosition = Player.Instance.GetPosition () ;
		Vector3 direction = (playerPosition - transform.position).normalized;
		Vector3 newPosition = transform.position + direction * dataMove.speed * Time.deltaTime;
		transform.parent.parent.position = newPosition;
	}


	public virtual bool CheckPlayerWithinAttackRange(){
		Vector3 playerPosition = Player.Instance.GetPosition ();
		float distanceFromPlayer = Vector3.Distance (playerPosition, transform.position);
		return distanceFromPlayer <= dataEnemy.attackRange;
	}

	public virtual bool CheckDistanceStopMoveFormPlayer(){
		Vector3 playerPosition = Player.Instance.GetPosition ();
		float distanceFromPlayer = Vector3.Distance (playerPosition, transform.position);
		return distanceFromPlayer <= dataEnemy.distanceStopMove;
	}
}
