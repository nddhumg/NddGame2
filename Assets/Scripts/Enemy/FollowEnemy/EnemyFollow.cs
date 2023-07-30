using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : FollowPlayer {
	[SerializeField]protected EnemyCtrl enemyCtrl;
	protected bool followingSateTransition;
	[SerializeField] protected float distanceStopFollow = 15;
	[SerializeField] protected float distanceFromPlayer;
	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadEnemyCtrl ();
	}
	protected override void Start(){
		base.Start ();
		StartCoroutine (Delay1Second());
	}
	IEnumerator Delay1Second(){
		while (true) {
			this.ActiveAnimationEnemy ();
			yield return new WaitForSeconds (1f);
		}
	}
	protected virtual void LoadEnemyCtrl(){
		if (this.enemyCtrl != null)
			return;
		this.enemyCtrl= transform.parent.parent.GetComponent<EnemyCtrl>();
		Debug.LogWarning ("Add EnemyCtrl", gameObject);
	}
	protected override void ResetValue ()
	{
		base.ResetValue ();
		this.speedFollow = 2.5f;
		distanceStopFollow = enemyCtrl.EnemySO.attackRange - 0.2f;
	}
	protected override void ChangeIsFollowing(){
		distanceFromPlayer = Vector3.Distance (transform.position, target.position);
		if (distanceFromPlayer > distanceStopFollow) {
			isFollowing = true;
		} else {
			isFollowing = false;
		}
	}
	protected override void Follow(){
		transform.parent.parent.position += direction * speedFollow * Time.deltaTime;
	}
	protected virtual void ActiveAnimationEnemy(){
		if (isFollowing) {
			enemyCtrl.AnimationEnemy.SetAnimationAttack (false);
		} else {
			enemyCtrl.AnimationEnemy.SetAnimationAttack (true);
		}
	}
}
