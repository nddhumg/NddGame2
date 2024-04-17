using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class HolySwordMove : NddBehaviour {
	[SerializeField] protected Vector3 endPosition;
	[SerializeField] protected float speed = 10f;
	[SerializeField] protected bool isToEndPosition = false;
	[SerializeField] protected float distanceOutsideCameraView = 13;
	[SerializeField] protected Vector3 nearPlayerPosition;
	public float Speed{
		set{ 
			speed = value;
		}
	}
	public void IncreaseSpeed(float value){
		speed += value;
	}
	protected override void Start ()
	{
		base.Start ();
		ChangeEndPositionToPlayer ();
		transform.parent.rotation = Quaternion.Euler(RotationToTheEndPosition ());
	}
	void Update(){
		Move ();
//		Debug.DrawLine (transform.position, endPosition, Color.red);
	}
	protected virtual void Move(){
		if (isToEndPosition == true)
			return;
		transform.parent.position = Vector3.MoveTowards (transform.position, endPosition, speed * Time.deltaTime);
		if (transform.position == endPosition) {
			isToEndPosition = true;
			DotTweenRotation ();
		}
	}
	protected virtual void DotTweenRotation(){
		ChangeEndPositionToPlayer ();
		transform.parent.DORotate (
			RotationToTheEndPosition(),
			1f
		).onComplete = SetFalseIsToEndPosition;
	}
	private void SetFalseIsToEndPosition(){
		isToEndPosition = false;
	}
	protected virtual Vector3 RotationToTheEndPosition(){
		return new Vector3(0, 0,Mathf.Atan2(endPosition.y - transform.position.y,endPosition.x - transform.position.x)*Mathf.Rad2Deg);
	}
	protected virtual void ChangeEndPositionToPlayer(){
		nearPlayerPosition = Player.Instance.GetPosition();
		nearPlayerPosition = new Vector2(nearPlayerPosition.x + Random.Range(-8,8),nearPlayerPosition.y + Random.Range(-5,5));
		Vector3 direction = (nearPlayerPosition - transform.position).normalized;
		endPosition = nearPlayerPosition + direction * distanceOutsideCameraView;
	}
}
