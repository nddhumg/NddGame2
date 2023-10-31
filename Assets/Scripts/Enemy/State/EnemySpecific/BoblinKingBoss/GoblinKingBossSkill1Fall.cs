using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinKingBossSkill1Fall : EnemySkill {
	GoblinKingBossStateManager enemy;
	public GoblinKingBossSkill1Fall(EnemyStateManager stateManager,StateMachine stateMachine,string animBoolName,GoblinKingBossStateManager enemy): base(stateManager,stateMachine,animBoolName){
		this.enemy = enemy;
	}
	private Vector3 groundingPosition;
	private float errorDistanceFormHeadToFoot = 1.3f;
	private bool isFinishState = false;
	private float attackAoeRadius = 3f;
	public override void Enter ()
	{
		base.Enter ();
		groundingPosition = GetGroundingPosition ();
		Vector3 newPosition = Player.Instance.GetPosition ();
		newPosition = new Vector3(newPosition.x,newPosition.y + 20f,0f);
		enemy.transform.parent.parent.position = newPosition;
		SpawnFxRedZone ();
	}
	private void SpawnFxRedZone(){
		enemy.transform.parent.parent.position = new Vector3 (groundingPosition.x,enemy.transform.position.y,0f);
		Transform fxRedZone = SpawnFx.Instance.Spawn (FxName.RedZone.ToString (), Player.Instance.GetPosition(), Quaternion.identity);
		fxRedZone.GetComponent<RedZone>().SetUp (attackAoeRadius);
	}
	public override void Exit ()
	{
		base.Exit ();
		groundingPosition = Vector3.zero;
		isFinishState = false;
		enemy.timerSkill1 = 0f;
	}
	private Vector3 GetGroundingPosition(){
		Vector3 grounding = Player.Instance.GetPosition ();
		grounding = new Vector3 (grounding.x,grounding.y +errorDistanceFormHeadToFoot,0f);
		return grounding;
	}
	public override void LogicUpdate ()
	{
		base.LogicUpdate ();
		SetUpState2 ();
		if (isFinishState) {
			stateMachine.ChangeState (enemy.idleState);
		}
	}
	private void SetUpState2(){
		if (groundingPosition == Vector3.zero) {
			groundingPosition = GetGroundingPosition ();
			enemy.transform.parent.parent.position = new Vector3 (groundingPosition.x, enemy.transform.position.y, 0);
		}
		enemy.MoveTo (groundingPosition,10);
		if (enemy.transform.position == groundingPosition) {
			AttackAoeSkill ();
			isFinishState = true;
		}
	}
	private void AttackAoeSkill(){
		Vector3 footPosition = new Vector3 (enemy.transform.position.x, enemy.transform.position.y - errorDistanceFormHeadToFoot, 0f);
		Collider2D collider = Physics2D.OverlapCircle (footPosition,attackAoeRadius,enemy.WhatAreSendDamageSkill);
		DamageReceiver receiver = collider?.transform.parent?.GetComponentInChildren<DamageReceiver> ();
		if (receiver == null)
			return;
		DamageSender damageSender = new DamageSender ();
		damageSender.Send (receiver,100);
	}

}
