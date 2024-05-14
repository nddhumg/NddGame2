using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveAbility : NddBehaviour {
	[Header("Active Ability")]
	[SerializeField] protected float delayAbility = 5f;
	[SerializeField] protected float timerAbility = 10f;
	[SerializeField] protected bool isReady = false;
	public float DelayAbility{
		get{
			return delayAbility;
		}
	}
	public float TimerAbility{
		get{
			return timerAbility;
		}
	}
	protected virtual void Update(){
		this.Timing ();
	}

	protected virtual void Timing(){
		if (timerAbility < delayAbility) {
			timerAbility += Time.deltaTime;
		}
		else
			this.isReady = true;	
	}
	protected virtual void ResetTiming(){
		timerAbility = 0;
		isReady = false;
	}
}
