using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiverPlayer : DamageReceiver {
	
	public override void ResetHp(){
		base.ResetHp ();
	}
	protected override void ResetValue ()
	{
		base.ResetValue ();
		this.hpMax = 100f;
	}
	protected override void LoadComponent(){
		base.LoadComponent ();
	}

	protected override void OnDead ()
	{
		Debug.Log (transform.parent.name + "Dead", gameObject);
	}
}
