using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarriorStateManager : NddBehaviour {
	public EnemyCtrl enemyCtrl;

	public EnemyWarriorState currentState;

	public EnemyWarriorMove MoveState;
	public EnemyWarriorAttack AttackState;

	protected override void Awake(){
		MoveState = new EnemyWarriorMove (this,"Move");
		AttackState = new EnemyWarriorAttack (this,"Attack");
	}
	void OnEnable(){
		StartState ();
	}

	void StartState(){
		currentState = MoveState;
		currentState.Enter ();
	}
	void Update(){
		currentState.LogicUpdate ();
	}
	void FixedUpdate(){
		currentState.PhySicsUpdate();
	}
	public void ChangeState(EnemyWarriorState newState){
		currentState.Exit ();
		currentState = newState;
		currentState.Enter ();
	}
	public void AnimationFinishTrigger(){
		currentState.AnimationFinishTrigger ();
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadEnemyCtrl ();
	}
	protected virtual void LoadEnemyCtrl(){
		if (this.enemyCtrl != null)
			return;
		this.enemyCtrl= transform.parent.parent.GetComponent<EnemyCtrl>();
		Debug.Log ("Add LevelPlayer", gameObject);
	}
}

