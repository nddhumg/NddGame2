using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAbility : NddBehaviour {
	[Header("Abiliyy")]
	[SerializeField] protected float delayAbility = 5f;
	[SerializeField] protected float timerAbility = 10f;
	[SerializeField] protected bool isReady = false;

	protected virtual void Update(){
		this.Timing ();
	}

	protected virtual void Timing(){
		if (timerAbility < delayAbility) {
			timerAbility += Time.deltaTime;
			this.isReady = false;
		}
		else
			this.isReady = true;	
	}
}
