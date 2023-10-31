using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinKingBossIdle : EnemyIdle {
	GoblinKingBossStateManager enemy;
	private SOIdle data;
	private bool isReadySkill1 ;
	private bool isReadyShot ;
	public GoblinKingBossIdle(EnemyStateManager stateManager,StateMachine stateMachine,string animBoolName,GoblinKingBossStateManager enemy,SOIdle data): base(stateManager,stateMachine,animBoolName){
		this.enemy = enemy;
		this.data = data;
	}
	public override void Enter ()
	{
		base.Enter ();
		isReadySkill1 = false;
	}
	public override void DoChecks ()
	{
		base.DoChecks ();
		isReadySkill1 = enemy.CheckReadySkill1 ();
		isReadyShot = enemy.CheckReadyShot();
	}
	public override void LogicUpdate ()
	{
		base.LogicUpdate ();
		if (Time.time < data.idleTime + startTime) {
		
		}
		else if (!isInStopDistance)
			stateMachine.ChangeState (enemy.moveState);
		else if (isReadySkill1)
			stateMachine.ChangeState (enemy.skill1JumbState);
		else if (isReadyShot)
			stateMachine.ChangeState (enemy.shotState);
	}
}
