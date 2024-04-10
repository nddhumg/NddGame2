using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DamageReceiverPlayer : DamageReceiver {
	[SerializeField] protected PlayerCtrl playerCtrl;
	public static event Action OnDeadEvent = delegate { };
	public  event Action OnReceiverEvent = delegate { };

	public override void Receiver(float damage){
		base.Receiver (damage);
		OnReceiverEvent?.Invoke ();
	}

	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadPlayerCtrl ();
	}

	protected virtual void LoadPlayerCtrl(){
		if (this.playerCtrl != null)
			return;
		this.playerCtrl= transform.GetComponentInParent<PlayerCtrl>();
		Debug.Log ("Add PlayerCtrl", gameObject);
	}

	protected override void ResetValueComponent ()
	{
		base.ResetValueComponent ();
		this.hpMax = playerCtrl.PlayerSO.hpMax;
		hp = hpMax;
	}
		
	protected override void OnDead()
	{
		OnDeadEvent?.Invoke ();
	}
}
