using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCircularPlayer : AbilityCircular,ISetDamagePlayer  {
	[Header("AbilityCircularPlayer")]
	[SerializeField] protected PlayerCtrl playerCtrl;
	[SerializeField] protected float damage;
	[SerializeField] protected float damageRatio =1f;

	public float DamageRatio{
		get{
			return damageRatio;
		}
		set
		{
			damageRatio = value;
		}
	}
	public float Damage{
		get{
			return damage;
		}
	}
	void OnEnable(){
		playerCtrl.AttributesPlayer.AddObsever (this);
		damage = playerCtrl.AttributesPlayer.Damage;
	}

	public void OnSetDamage(float damage){
		this.damage = damage * damageRatio;
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		ConvertPlayerCtrl ();
	}
	protected virtual void ConvertPlayerCtrl(){
		if (playerCtrl != null)
			return;
		this.playerCtrl = ability.ObjectCtrl as PlayerCtrl;;
		Debug.LogWarning ("Convert LevelAbility");
	}
	protected override void ResetValue ()
	{
		base.ResetValue ();
		speed = 1.5f;
	}
	protected override void SetCenterPosition ()
	{
		centerPosition = transform;
	}
}
