using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSenderEnemyWarrior : DamageSenderEnemy {
	[Header("Damage Sender Enemy Warrior")]
	[SerializeField] protected EnemyWarriorCtrl enemyWarriorCtrl;
	protected override void LoadComponent ()
	{
		this.LoadEnemyWarriorCtrl ();
		base.LoadComponent ();
	}
	protected override void SetCircleCollider2D ()
	{
		circleCollider2D.offset = enemyWarriorCtrl.EnemyWarriorSO.offsetZoneAttack;
		circleCollider2D.radius = enemyWarriorCtrl.EnemyWarriorSO.attackRange;
	}
	protected virtual void LoadEnemyWarriorCtrl(){
		if (this.enemyWarriorCtrl != null)
			return;
		this.enemyWarriorCtrl= transform.parent.GetComponent<EnemyWarriorCtrl>();
		Debug.LogWarning ("Add EnemyCtrl", gameObject);
	}
	protected override void SetDamageWhenReset ()
	{
		this.damage = enemyWarriorCtrl.EnemyWarriorSO.damage;
	}
}
