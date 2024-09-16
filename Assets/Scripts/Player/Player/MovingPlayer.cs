using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovingPlayer : NddBehaviour {
	[SerializeField]protected Vector2 direction ;
    [SerializeField]protected float speed = 4.3f;
	[SerializeField]protected PlayerCtrl playerCtrl;
	private Action GetDirectionMove;
	protected override void Start ()
	{
		base.Start ();
		if(MainPlay.Instance.IsMobi){
			GetDirectionMove += GetDirectionMobi;
		}
		else
		{
			GetDirectionMove += GetDirectionPc;
		}
	}
	void Update()
	{
		Moving ();
	}

	public float Speed{
		get{
			return speed;
		}
	}
	public Vector2 Direction{
		get{ 
			return direction;
		}
	}
	protected override void ResetValueComponent ()
	{
		speed = playerCtrl.StatsSO.GetValueStat (StatsName.Speed);
	}
	public virtual void SetSpeedMoving(float setSpeed){
		this.speed = setSpeed;
	}
	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadPlayerCtrl (); 
	}
	protected virtual void LoadPlayerCtrl(){
		if (this.playerCtrl != null)
			return;
		this.playerCtrl= transform.GetComponentInParent<PlayerCtrl>();
		Debug.LogWarning ("Add PlayerCtrl", gameObject);
	}
	protected void GetDirectionPc(){
		direction.x = InputManager.Instance.KeyHorizontal;
		direction.y = InputManager.Instance.KeyVertical;
	}
	protected void GetDirectionMobi (){
		direction = JoyStickMove.Instance.Direction;
	}
	protected virtual void Moving(){
		GetDirectionMove?.Invoke ();
		if (direction == Vector2.zero) {
			playerCtrl.AnimationPlayer.SetAnimationRuning (false);
			playerCtrl.PhysicsPlayer.Rig2d.velocity = Vector2.zero;
			return;
		}
		playerCtrl.AnimationPlayer.SetAnimationRuning (true);
		direction =  direction.normalized;
		SwapScaleIsMoving ();
		playerCtrl.PhysicsPlayer.Rig2d.velocity = new Vector2 (direction.x * speed, direction.y * speed);
	}
	protected virtual void SwapScaleIsMoving(){
		int direction = this.direction.x > 0 ? 1 : -1;
		playerCtrl.Model.transform.localScale = new Vector3(direction ,transform.parent.localScale.y,transform.parent.localScale.z);	
	}

}
