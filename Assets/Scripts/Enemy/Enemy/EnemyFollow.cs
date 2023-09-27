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
	void OnEnable(){
		StartCoroutine (Delay1Second());
	}
	IEnumerator Delay1Second(){
		while (true) {
			this.ActiveAnimationEnemy ();
			yield return new WaitForSeconds (1f);
		}
	}
	protected virtual void FixedUpdate(){
		SetRotationByTarget ();
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
	}
	protected override void ResetValueComponent ()
	{
		base.ResetValueComponent ();
		distanceStopFollow = enemyCtrl.EnemySO.attackRange ;
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
			enemyCtrl.AnimationEnemy.SetAnimationFollow (true);
		} else {
			enemyCtrl.AnimationEnemy.SetAnimationFollow (false);
		}
	}
	protected virtual void SetRotationByTarget(){
		if (target == null)
			return;
		if (target.position.x > transform.position.x) {
			enemyCtrl.Model.transform.localScale = new Vector3 (1f, 1f, 1f);
		} else {
			enemyCtrl.Model.transform.localScale = new Vector3 (-1f, 1f, 1f);
		}
	}
}
