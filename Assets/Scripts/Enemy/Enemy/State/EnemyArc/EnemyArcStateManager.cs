using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcStateManager : NddBehaviour {
	public EnemyArcCtrl enemyArcCtrl;

	public EnemyArcState currentState;
	public EnemyArcState IdleState;
	public EnemyArcState MoveState;
	public EnemyArcState ShootState;

	protected override void Awake(){
		IdleState = new EnemyArcIdle (this,"Idle");
		MoveState = new EnemyArcMove (this,"Move");
		ShootState = new EnemyArcShoot (this,"Shoot");
	}

	void OnEnable(){
		StartState ();
	}

	void StartState(){

		currentState = IdleState;
		currentState.Enter ();
	}
	void Update(){
		currentState.LogicUpdate ();
	}
	void FixedUpdate(){
		currentState.PhySicsUpdate();
	}
	public void ChangeState(EnemyArcState newState){
		currentState.Exit ();
		currentState = newState;
		currentState.Enter ();
	}

	public void AnimationFinishTrigger(){
		currentState.AnimationFinishTrigger ();
	}
	public void Shot(){
		enemyArcCtrl.ShotEnemy.ShootBullet (transform.position);
	}

	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadEnemyArcCtrl ();
	}
	private  void LoadEnemyArcCtrl(){
		if (this.enemyArcCtrl != null)
			return;
		this.enemyArcCtrl= transform.parent.parent.GetComponent<EnemyArcCtrl>();
		Debug.Log ("Add EnemyArcCtrl", gameObject);
	}
}
