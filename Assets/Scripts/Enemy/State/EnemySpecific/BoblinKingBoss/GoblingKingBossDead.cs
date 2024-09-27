using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblingKingBossDead : EnemyState {
	GoblinKingBossStateManager enemy;
	public GoblingKingBossDead(EnemyStateManager stateManager,StateMachine stateMachine,string animBoolName,GoblinKingBossStateManager enemy): base(stateManager,stateMachine,animBoolName){
		this.enemy = enemy;
	}
	private bool isUseSkillDead = false;
	public override void Enter ()
	{
		base.Enter ();
		if (!isUseSkillDead) {
			stateMachine.ChangeState (enemy.skillLastStandHealState);
		} else {
			enemy.Ctrl.DestroyEnemy.DestroyObject ();
			enemy.Ctrl.DamageReceiverBoss.InvokeDeadEvent ();
			enemy.Ctrl.DamageReceiverEnemy.DropItemWhenDead ();
		}
	}
	public override void Exit ()
	{
		base.Exit ();
		isUseSkillDead = true;
	}
}
