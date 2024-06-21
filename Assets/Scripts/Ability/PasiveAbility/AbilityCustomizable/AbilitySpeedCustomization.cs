using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySpeedCustomization : AbilityCustomizableObject {
	protected MovingPlayer movingPlayer;

	public AbilitySpeedCustomization(MovingPlayer move){
		this.movingPlayer = move;
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