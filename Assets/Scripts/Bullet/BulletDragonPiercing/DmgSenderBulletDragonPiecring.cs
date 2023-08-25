using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgSenderBulletDragonPiecring : DmgSenderBulletPiercing {
	[Header("Dmg Sender Bullet Dragon Piecring")]
	[SerializeField] protected float damageIncreaseRatio = 5;
	public override void SetDamage (float damage)
	{
		base.SetDamage (damage);
		this.damage *= 5;
	}
}
