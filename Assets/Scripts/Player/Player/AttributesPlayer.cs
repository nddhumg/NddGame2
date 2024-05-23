using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesPlayer : NddBehaviour{
	[SerializeField] protected PlayerCtrl playerCtrl;
	[SerializeField]protected float damage =1;
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
		NotifyObsevers (damage);
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

	[SerializeField]private List<ISetDamagePlayer> obsevers = new List<ISetDamagePlayer>();

	public void AddObsever(ISetDamagePlayer obsever){
		obsevers.Add (obsever);
	}
	public void RemoveObsever(ISetDamagePlayer obsever){
		obsevers.Remove (obsever);
	}
	protected void NotifyObsevers(float damage){
		foreach (ISetDamagePlayer obsever in obsevers) {
			obsever.OnSetDamage (damage);
		}
	}
}
