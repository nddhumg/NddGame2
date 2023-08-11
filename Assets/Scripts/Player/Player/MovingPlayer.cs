using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayer : NddBehaviour {
    [SerializeField]protected Vector4 keyTarget ;
    [SerializeField]protected float speedMoving = 3f;
	[SerializeField]protected Vector2 limitPos = new Vector2 (31.5f, 19.6f);
	[SerializeField]protected PlayerCtrl playerCtrl;

	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadPlayerCtrl (); 
	}
	public void SpeedUp(float valueSpeedUp){
		speedMoving += valueSpeedUp;
	}
	protected virtual void LoadPlayerCtrl(){
		if (this.playerCtrl != null)
			return;
		this.playerCtrl= transform.GetComponentInParent<PlayerCtrl>();
		Debug.Log ("Add PlayerCtrl", gameObject);
	}
	public Vector2 LimitPos{
		get{
			return limitPos;
		}
	}
    void Update()
    {
        this.Moving();
		this.HandRunAnimation ();
    }
	void FixedUpdate(){
		this.SetPosByLimit ();
	}
    protected virtual void Moving() {
        this.keyTarget = InputManager.Instance.KeyMoving;
        float speed = this.speedMoving * Time.deltaTime;
		this.MovementUnLimited (speed);
    }

	protected virtual void MovementUnLimited(float speed){
		
		if (this.keyTarget.x == 1 && transform.position.x < limitPos.x)
		{
			// RIGHT
			this.SwapScaleIsMoving(1);
			this.MovingAdditionPos(new Vector3(speed, 0, 0));
		}
		if (this.keyTarget.y == 1 && transform.position.x > -limitPos.x)
		{
			// LEFT
			this.SwapScaleIsMoving(-1);
			this.MovingAdditionPos(new Vector3(-speed, 0, 0));
		}
		if (this.keyTarget.z == 1 && transform.position.y > -limitPos.y)
		{
			// DOWN
			this.MovingAdditionPos(new Vector3(0, -speed, 0));
		}
		if (this.keyTarget.w == 1 && transform.position.y < limitPos.y)
		{
			// UP
			this.MovingAdditionPos(new Vector3(0, speed, 0));
		}
	}
	protected virtual void SetPosByLimit(){
		Vector3 posParent = transform.parent.position;
		if(posParent.x >= limitPos.x){
			transform.parent.position += new Vector3(-1f,0,0) *Time.fixedDeltaTime;
		}
		if(posParent.x <= -limitPos.x){
			transform.parent.position += new Vector3(1f,0,0)*Time.fixedDeltaTime;
		}
		if(posParent.y <= -limitPos.y){
			transform.parent.position += new Vector3(0,1f,0)*Time.fixedDeltaTime;
		}
		if(posParent.y >= limitPos.y){
			transform.parent.position += new Vector3(0,-1f,0)*Time.fixedDeltaTime;
		}
	}
	protected virtual void HandRunAnimation(){
		if (this.keyTarget == Vector4.zero) {
			playerCtrl.AnimationPlayer.SetAnimationRuning (false);
		} else {
			playerCtrl.AnimationPlayer.SetAnimationRuning (true);
		}
	}

    protected virtual void MovingAdditionPos(Vector3 direction) {
        transform.parent.position += direction;
    }
	protected virtual void SwapScaleIsMoving(int direction){
		playerCtrl.Model.transform.localScale = new Vector3(direction ,transform.parent.localScale.y,transform.parent.localScale.z);	
	}

}
