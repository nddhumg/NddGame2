using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSenderBoss : DamageSenderEnemy {
	[Header("Damage Sender Boss")]
	[SerializeField] protected BossCtrl bossCtrl;
	protected override void LoadComponent ()
	{
		this.LoadEnemyWarriorCtrl ();
		base.LoadComponent ();
	}
	protected override void SetCapsuleCollider2D ()
	{
		capsuleCollider2D.offset = bossCtrl.BossSO.offsetZoneAttack;
		capsuleCollider2D.size = new Vector2(bossCtrl.BossSO.attackRange, bossCtrl.BossSO.attackRange);
	}
	protected virtual void LoadEnemyWarriorCtrl(){
		if (this.bossCtrl != null)
			return;
		this.bossCtrl= transform.parent.GetComponent<BossCtrl>();
		Debug.LogWarning ("Add EnemyCtrl", gameObject);
	}
	protected override void SetDamageWhenReset ()
	{
		this.damage = bossCtrl.BossSO.damage;
	}
}
