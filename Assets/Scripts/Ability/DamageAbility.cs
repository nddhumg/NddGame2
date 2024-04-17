using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAbility : NddBehaviour {
	[SerializeField] protected float damage = 1f;
	[SerializeField] protected float baseDamage = 1f;
	[SerializeField] protected float damageRatio =1f;

	public float DamageRatio{
		get{
			return damageRatio;
		}
	}
	public float Damage{
		get{
			return damage;
		}
	}
	public virtual void SetDamageRatio(float damageRatio){
		this.damageRatio = damageRatio;
		damage = baseDamage * damageRatio;
	}
}
