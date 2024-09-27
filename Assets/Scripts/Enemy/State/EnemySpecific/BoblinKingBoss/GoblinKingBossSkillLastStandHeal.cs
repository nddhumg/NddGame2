using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinKingBossSkillLastStandHeal : EnemyState {
	GoblinKingBossStateManager enemy;
	public GoblinKingBossSkillLastStandHeal(EnemyStateManager stateManager,StateMachine stateMachine,string animBoolName,GoblinKingBossStateManager enemy,DamageReceiver damageReceiver,float hpPercentageRecovery): base(stateManager,stateMachine,animBoolName){
		this.enemy = enemy;
		this.damageReceiver = damageReceiver;
		this.hpPercentageRecovery = hpPercentageRecovery;
	}
	private float hpPercentageRecovery;
	private DamageReceiver damageReceiver;
	private int hpRecovery ;

	public override void Enter ()
	{
		base.Enter ();
		hpRecovery = (int)(hpPercentageRecovery * damageReceiver.HpMax);
		enemy.SetIsTrigger (false);
		enemy.StartCoroutine (Reconvering());
	}

	public override void SetAnimationEnter ()
	{
		base.SetAnimationEnter ();
		stateManager.anim.SetTrigger ("LastStandHealTrigger");
	}

	private IEnumerator Reconvering(){
		int restoryHpPerTrigger = hpRecovery / 6;
		while (hpRecovery > 0) {
			int hpHeling = 0;
			if (hpRecovery - restoryHpPerTrigger >= 0) {
				hpHeling = restoryHpPerTrigger;
			} else {
				hpHeling = hpRecovery;
			}
			damageReceiver.AddHp (hpHeling);
			hpRecovery -= hpHeling;
			SpawnFx.Instance.Spawn (FxName.FxDamagePopUp.ToString(), enemy.transform.position, Quaternion.identity).GetComponent<DamagePopUp>().SetUp(hpHeling,Color.green);
			yield return new WaitForSeconds (0.5f);
			Debug.Log(hpRecovery);
		}
		stateMachine.ChangeState (enemy.idleState);
	}

}
