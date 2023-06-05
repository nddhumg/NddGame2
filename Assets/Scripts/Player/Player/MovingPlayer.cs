using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayer : NddBehaviour {
    [SerializeField]protected Vector4 keyTarget ;
    [SerializeField]protected float speedMoving = 3f;


    void Update()
    {
        this.Moving();
		this.HandRunAnimation ();
    }

    protected virtual void Moving() {
        this.keyTarget = InputManager.Instance.KeyMoving;
        float speed = this.speedMoving * Time.deltaTime;
        if (this.keyTarget.x == 1)
        {
            // RIGHT
			this.SwapScaleIsMoving(1);
            this.MovingAdditionPos(new Vector3(speed, 0, 0));
        }
        if (this.keyTarget.y == 1)
        {
            // LEFT
			this.SwapScaleIsMoving(-1);
            this.MovingAdditionPos(new Vector3(-speed, 0, 0));
        }
        if (this.keyTarget.z == 1)
        {
            // DOWN
            this.MovingAdditionPos(new Vector3(0, -speed, 0));
        }
        if (this.keyTarget.w == 1)
        {
            // UP
            this.MovingAdditionPos(new Vector3(0, speed, 0));
        }

    }
	protected virtual void HandRunAnimation(){
		if (this.keyTarget == Vector4.zero) {
			PlayerCtrl.Instance.AnimationPlayer.SetAnimationRuning (false);
		} else {
			PlayerCtrl.Instance.AnimationPlayer.SetAnimationRuning (true);
		}
	}
    protected virtual void MovingAdditionPos(Vector3 direction) {
        transform.parent.position += direction;
    }
	protected virtual void SwapScaleIsMoving(int direction){
		transform.parent.localScale = new Vector3(direction ,transform.parent.localScale.y,transform.parent.localScale.z);	
	}
}
