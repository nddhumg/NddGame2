using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinKingBossSkill1Jump : EnemySkill {
	GoblinKingBossStateManager enemy;
	public GoblinKingBossSkill1Jump(EnemyStateManager stateManager,StateMachine stateMachine,string animBoolName,GoblinKingBossStateManager enemy): base(stateManager,stateMachine,animBoolName){
		this.enemy = enemy;
	}

	private float delayState = 5f;
	private bool isStartJumb;

	public override void Enter ()
	{
		base.Enter ();
		enemy.SetIsTrigger(true);
	}
	public override void Exit ()
	{
		base.Exit ();
		isStartJumb = false;
	}
	public override void LogicUpdate ()
	{
		base.LogicUpdate ();
		if (isStartJumb) {
			JumbSkill ();
		}
	}
	private void JumbSkill(){
		Vector3 positionNewUp = new Vector3 (enemy.transform.position.x, 100f, 0f);
		enemy.MoveTo (positionNewUp,10f);
		if (Time.time > startTime + delayState) {
			stateMachine.ChangeState (enemy.skill1FallState);
		}
	} 

	public void StartJumb(){
		isStartJumb = true;
	}
}
