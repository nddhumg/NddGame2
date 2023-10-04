using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CapsuleCollider2D))]
public abstract class DamageSender : NddBehaviour {
    [SerializeField] protected float damage = 1f;
	[SerializeField] protected CapsuleCollider2D capsuleCollider2D;

	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadCapsuleCollider2D (); 
	}
	protected virtual void LoadCapsuleCollider2D(){
		if(this.capsuleCollider2D != null)
			return;
		this.capsuleCollider2D = GetComponent<CapsuleCollider2D> ();
		this.capsuleCollider2D.isTrigger = true;
		SetCapsuleCollider2D ();
		Debug.Log("Add CapsuleCollider2D",gameObject);
	}
	protected abstract void SetCapsuleCollider2D ();
	public virtual void Send(Transform objRecever) { 
        DamageReceiver receiver = objRecever.GetComponentInChildren<DamageReceiver>();
		if (receiver == null)
			return;
		Send (receiver);  
    }
	protected virtual void Send(DamageReceiver receiver) {
        receiver.Receiver(this.damage);
		SpawnDamagePopUp ();
    }
	protected virtual void SpawnDamagePopUp(){
		Transform fxDamagePopUp = SpawnFx.Instance.Spawn (FxName.FxDamagePopUp.ToString(),transform.position,Quaternion.identity);
		DamagePopUp popUp = fxDamagePopUp.GetComponent<DamagePopUp>();
		popUp.SetUp (damage);
	}
	public virtual void SetDamage(float damage){
		this.damage = damage;
	}
}
