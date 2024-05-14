using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDashPlayer : AbilityDashbyRigidbody2D {
	[Header("Dash Ability Player")]
	[SerializeField] protected bool keyDash;
	[SerializeField] protected PlayerCtrl playerCtrl;

	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadPlayerCtrl (); 
	}

	protected virtual void LoadPlayerCtrl(){
		if (this.playerCtrl != null)
			return;
		this.playerCtrl= transform.root.GetComponent<PlayerCtrl>();
		Debug.LogWarning ("Add PlayerCtrl", gameObject);
	}
	protected override void ResetValue ()
	{
		base.ResetValue ();
		dashDistance = 5f;
	}
	protected override void Update()
	{
		base.Update ();
		GetKeyDashAbility ();
		this.CheckDash ();
	}
	protected virtual void GetKeyDashAbility(){
		keyDash = InputManager.Instance.KeySpace;
	}
	protected virtual void CheckDash(){
		if (!isReady)
			return;
		if (!this.keyDash)
			return;
		dashDirection =  playerCtrl.MovingPlayer.KeyMoving;
		dashDirection = dashDirection.normalized;
		if (dashDirection == Vector2.zero)
			return;
		Dash();
		ResetTiming ();
	}
}
