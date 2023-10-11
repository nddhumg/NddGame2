using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerAbility : DamageAbility,ISetDamagePlayer {
	[Header("Damage Player Ability")]
	[SerializeField] protected PlayerCtrl playerCtrl;
	void OnEnable(){
		playerCtrl.AttributesPlayer.AddObsever (this);
		baseDamage = playerCtrl.AttributesPlayer.Damage;
		damage = baseDamage;
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadPlayerCtrl ();
	}
	protected virtual void LoadPlayerCtrl(){
		if (playerCtrl != null)
			return;
		playerCtrl = transform.root.GetComponent<PlayerCtrl>();
		Debug.LogWarning ("Add PlayerCtrl",gameObject);
	}
	public void OnSetDamage(float damagePlayer){
		this.damage = damage * damageRatio;
		baseDamage = damage;
	}
}
