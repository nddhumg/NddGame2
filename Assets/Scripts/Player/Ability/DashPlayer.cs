using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPlayer : DashAbilityByDistance {
	[Header("Dash Ability Player")]
	[SerializeField] protected bool keyDash;
	[SerializeField] protected Vector4 keyMoving;
	[SerializeField] protected float delayTime = 5f;
	[SerializeField] protected float timer = 2f;
	[SerializeField] protected PlayerCtrl playerCtrl;
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
	protected override void ResetValue ()
	{
		base.ResetValue ();
		dashSpeed = 20f;
		dashDistance = 2f;
	}
	protected override void Update()
	{
		base.Update ();
		keyMoving = InputManager.Instance.KeyMoving;
		GetKeyDashAbility ();
		this.SurfPlayer ();
	}
	protected virtual void CalculateDirection() {
		dashDirection = new Vector2(0, 0);
        if (keyMoving.x == 1) {
			dashDirection.x += 1;
        }
        if (keyMoving.y == 1) {
			dashDirection.x -= 1;
        }
        if (keyMoving.z == 1)
        {
			dashDirection.y -= 1;
        }
        if (keyMoving.w == 1)
        {
			dashDirection.y += 1;
        }
    }
	protected virtual void GetKeyDashAbility(){
		 this.keyDash = InputManager.Instance.KeySpace;
	}
	protected virtual void SurfPlayer(){
		if (!isReady)
			return;
		if (!this.keyDash)
			return;
		if (this.keyMoving == Vector4.zero)
			return;
		timerAbility = 0f;
		playerCtrl.AnimationPlayer.SetAnimationSurf (true);
		CalculateDirection ();
		StartCoroutine(Dash());
	}
	protected override void StopSurf(){
		base.StopSurf ();
		playerCtrl.AnimationPlayer.SetAnimationSurf (false);
	}
	protected override void UnannouncedConditions(){
		Vector2 limit =  playerCtrl.MovingPlayer.LimitPos;
		Vector3 pos = transform.position; 
		if (pos.x > limit.x || pos.x < -limit.x || pos.y > limit.y || pos.y < -limit.y)
			this.conflict = true;
		else
			this.conflict = false;
	}
}
