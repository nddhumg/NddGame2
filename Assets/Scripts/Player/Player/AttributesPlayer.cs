using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AttributesPlayer : NddBehaviour{
	[SerializeField] protected PlayerCtrl playerCtrl;
	[SerializeField]protected float damage =1;
	public event Action<float> OnModificationDanageEvent;
	protected float minDamage =1;
	public float Damage{
		get{ 
			return damage;
		}
	}
	private bool IsLimitDamage(float damage){
		return damage < minDamage;
	}
	public void SetDamage(float damage){
		if (IsLimitDamage (damage))
			return;
		this.damage = damage;
		OnModificationDanageEvent?.Invoke (damage);
	}

	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadPlayerCtrl ();
	}
	protected override void ResetValueComponent ()
	{
		base.ResetValueComponent ();
		damage = playerCtrl.StatsSO.GetValueStat(StatsName.Damage);
	}
	protected virtual void LoadPlayerCtrl(){
		if (this.playerCtrl != null)
			return;
		this.playerCtrl= transform.GetComponentInParent<PlayerCtrl>();
		Debug.Log ("Add PlayerCtrl", gameObject);
	}

}
