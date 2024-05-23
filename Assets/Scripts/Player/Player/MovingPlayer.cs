using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayer : NddBehaviour {
	[SerializeField]protected Vector2 keyMoving ;
    [SerializeField]protected float speed = 4.3f;
	[SerializeField]protected PlayerCtrl playerCtrl;

	void Update()
	{
		Moving ();
	}

	public float SpeedMoving{
		get{
			return speed;
		}
	}
	public Vector2 KeyMoving{
		get{ 
			return keyMoving;
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
    protected virtual void GetKeyMoving() {
		keyMoving.x = InputManager.Instance.KeyHorizontal;
		keyMoving.y = InputManager.Instance.KeyVertical;
    }

	protected virtual void Moving(){
		GetKeyMoving ();
		if (keyMoving == Vector2.zero) {
			playerCtrl.AnimationPlayer.SetAnimationRuning (false);
			playerCtrl.PhysicsPlayer.Rig2d.velocity = Vector2.zero;
			return;
		}
		playerCtrl.AnimationPlayer.SetAnimationRuning (true);
		keyMoving =  keyMoving.normalized;
		SwapScaleIsMoving ();
		playerCtrl.PhysicsPlayer.Rig2d.velocity = new Vector2 (keyMoving.x * speed, keyMoving.y * speed);
	}
	protected virtual void SwapScaleIsMoving(){
		int direction = keyMoving.x > 0 ? 1 : -1;
		playerCtrl.Model.transform.localScale = new Vector3(direction ,transform.parent.localScale.y,transform.parent.localScale.z);	
	}

}
