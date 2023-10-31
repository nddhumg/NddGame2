using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinKingBossStateManager : EnemyStateManager {
	
	public GoblinKingBossIdle idleState;
	public GoblinKingBossMove moveState;
	public GoblinKingBossShot shotState;
	public GoblinKingBossSkill1Jump skill1JumbState;
	public GoblinKingBossSkill1Fall skill1FallState;


	public SOShot dataShot;
	public SOSkill dataSkill1;
	public SOIdle dataIdle;

	public LayerMask WhatAreSendDamageSkill;
	[SerializeField]protected AbilityShot shot;
	public DamageSender damageSender;
	public float timerSkill1;
	[SerializeField]protected float timerShot;

	protected override void Start ()
	{
		base.Start ();
		stateMachine.FirshState (idleState);
	}
	protected override void Awake ()
	{
		base.Awake ();
		idleState = new GoblinKingBossIdle (this,stateMachine,"Idle",this,dataIdle);
		moveState = new GoblinKingBossMove (this,stateMachine,"Move",this);
		shotState = new GoblinKingBossShot (this,stateMachine,"Shoot",this);
		skill1JumbState = new GoblinKingBossSkill1Jump (this,stateMachine,"Skill1Jump",this);
		skill1FallState = new GoblinKingBossSkill1Fall (this,stateMachine,"Skill1Fall",this);
	}
	protected override void Update(){
		base.Update ();
		if (timerShot < dataShot.timeDelay )
			timerShot += Time.deltaTime;
		if (timerSkill1 < dataSkill1.delaySkill)
			timerSkill1 += Time.deltaTime;
	}
	public virtual bool CheckReadyShot(){
		return timerShot > dataShot.timeDelay;
	}
	public virtual bool CheckReadySkill1(){
		return timerSkill1 > dataSkill1.delaySkill;
	}
	public void MoveTo(Vector3 positionNew,float speed){
		transform.parent.parent.position = Vector3.MoveTowards(transform.position, positionNew, speed * Time.deltaTime);
	}
	public virtual void Shot(){
		timerShot =0;
		shot.ShootBullet (transform.position);
	}
	public virtual void StartJumbSkill1(){
		skill1JumbState.StartJumb ();
	}
}
