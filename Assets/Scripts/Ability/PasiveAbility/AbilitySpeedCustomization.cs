using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySpeedCustomization : AbilityCustomizableObject {
	[SerializeField] protected MovingPlayer movingPlayer;

	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadMovingPlayer ();
	}
	protected virtual void LoadMovingPlayer(){
		if (this.movingPlayer != null)
			return;
		this.movingPlayer = transform.parent.parent.parent.GetComponentInChildren<MovingPlayer>();
		Debug.LogWarning ("Add DamageReceiver", gameObject);
	}
	protected override void GetParameter(){
		this.parameter = movingPlayer.SpeedMoving;
	}
	protected override void ParameterIcrease (float hpMaxModified){
		this.parameterCompleted = parameter + hpMaxModified;
	}
	protected override void ParameterDecrease(float hpMaxModified){
		this.parameterCompleted = parameter - hpMaxModified;
	}
	protected override void SetParameter (){
		movingPlayer.SetSpeedMoving(this.parameterCompleted);
	}
}