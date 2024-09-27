using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 public class DamageReceiverBoss : DamageReceiverEnemy {
	public event Action OnDeadEvent = delegate { };
	protected override void OnDead ()
	{
		base.OnDead ();
		OnDeadEvent?.Invoke ();
	}
	public void InvokeDeadEvent(){
		OnDeadEvent?.Invoke ();
	}
}
