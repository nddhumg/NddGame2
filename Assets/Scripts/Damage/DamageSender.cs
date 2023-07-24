using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : NddBehaviour {
    [SerializeField] protected float damage = 1f;

	public virtual void Send(Transform objRecever) { 
        DamageReceiver receiver = objRecever.GetComponentInChildren<DamageReceiver>();
		Send (receiver);  
    }
	protected virtual void Send(DamageReceiver receiver) {
        receiver?.Receiver(this.damage);
    }
}
