using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public  class PickUpItem : NddBehaviour {
	[SerializeField]private CircleCollider2D circleCollider2D;
	[SerializeField]private Rigidbody2D rigid2D;
	[SerializeField] protected float maxRangePickUp = 3f;
	[SerializeField] protected float currentRangePickUp = 0.8f;
	public float CurrentRangePickUp{
		get{
			return currentRangePickUp;
		}
	}
	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadCircleCollider2D ();
		this.LoadRigidbody2D ();
	}
	protected virtual void LoadCircleCollider2D(){
		if (this.circleCollider2D != null)
			return;
		this.circleCollider2D= GetComponent<CircleCollider2D>();
		Debug.Log ("Add CircleCollider2D", gameObject);
		this.circleCollider2D.isTrigger = true;
		this.circleCollider2D.radius = 0.8f;
	}
	protected virtual void LoadRigidbody2D(){
		if (this.rigid2D != null)
			return;
		this.rigid2D= GetComponent<Rigidbody2D>();
		Debug.Log ("Add Rigidbody2D", gameObject);
		this.rigid2D.isKinematic = true;
	}
	protected  virtual void OnTriggerEnter2D(Collider2D col){
		PickUpAbleItem pickupItem = col.transform.parent.GetComponentInChildren<PickUpAbleItem> ();
		if (pickupItem == null)
			return;
		pickupItem.PickUpAble ();
	}
	public virtual void SetRangePickUp(float rangePickUpNew){
		if (rangePickUpNew > maxRangePickUp) {
			currentRangePickUp = maxRangePickUp;
			this.circleCollider2D.radius = currentRangePickUp;
			return;
		}
		currentRangePickUp = rangePickUpNew;
		this.circleCollider2D.radius = currentRangePickUp;
	}
}
