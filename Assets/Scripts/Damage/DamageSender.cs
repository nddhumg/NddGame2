using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CapsuleCollider2D))]
public  class DamageSender : NddBehaviour {
    [SerializeField] protected float damage = 1f;
	[SerializeField] protected CapsuleCollider2D capsuleCollider2D;
	[SerializeField] protected Vector2 offsetCapsuleColliser = new Vector2(0f,0f);
	[SerializeField] protected Vector2 sizeCapsuleColliser = new Vector2(1f,1f);

	public virtual void Send(Transform objReceiver) { 
		DamageReceiver receiver = objReceiver.GetComponentInChildren<DamageReceiver>();
		if (receiver == null)
			return;
		Send (receiver);  
	}
	public virtual void Send(Transform objReceiver,float damage) { 
		DamageReceiver receiver = objReceiver.GetComponentInChildren<DamageReceiver>();
		if (receiver == null)
			return;
		Send (receiver,damage);  
	}
	public virtual void Send(DamageReceiver receiver) {
		receiver.Receiver(this.damage);
		SpawnDamagePopUp (receiver.transform.position);
	}
	public virtual void Send(DamageReceiver receiver,float damage){
		receiver.Receiver(damage);
		SpawnDamagePopUp (receiver.transform.position,damage);
	}
	public virtual void SetDamage(float damage){
		this.damage = damage;
	}
	protected override void ResetValueComponent ()
	{
		base.ResetValueComponent ();
		SetCapsuleCollider2D ();
	}
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
		Debug.LogWarning("Add CapsuleCollider2D",gameObject);
	}
	protected virtual void SetCapsuleCollider2D (){
		if (this.capsuleCollider2D == null) {
			Debug.LogError ("Dont collision",gameObject);
			return;
		}
		capsuleCollider2D.offset = offsetCapsuleColliser;
		capsuleCollider2D.size = sizeCapsuleColliser;
	}
	protected virtual void SpawnDamagePopUp(Vector3 position){
		Vector3 positionSpawn = position;
		Transform fxDamagePopUp = SpawnFx.Instance.Spawn (FxName.FxDamagePopUp.ToString(),positionSpawn,Quaternion.identity);
		DamagePopUp popUp = fxDamagePopUp.GetComponent<DamagePopUp>();
		popUp.SetUp (damage);
	}
	protected virtual void SpawnDamagePopUp(Vector3 position,float damage){
		Vector3 positionSpawn = position;
		Transform fxDamagePopUp = SpawnFx.Instance.Spawn (FxName.FxDamagePopUp.ToString(),positionSpawn,Quaternion.identity);
		DamagePopUp popUp = fxDamagePopUp.GetComponent<DamagePopUp>();
		popUp.SetUp (damage);
	}
}
