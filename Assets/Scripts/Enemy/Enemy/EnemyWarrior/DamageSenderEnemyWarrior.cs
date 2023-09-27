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
	protected override void SetCapsuleCollider2D ()
	{
		capsuleCollider2D.offset = enemyWarriorCtrl.EnemyWarriorSO.offsetZoneAttack;
		capsuleCollider2D.size = new Vector2 ( enemyWarriorCtrl.EnemyWarriorSO.attackRange,  enemyWarriorCtrl.EnemyWarriorSO.attackRange);
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
