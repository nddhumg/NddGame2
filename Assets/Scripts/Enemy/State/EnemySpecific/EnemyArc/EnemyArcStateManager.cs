using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcStateManager : EnemyStateManager {
	public EnemyState idleState;
	public EnemyState moveState;
	public EnemyState shotState;

	[SerializeField]protected AbilityShot shot;
	[SerializeField] protected SOShot dataShot;

	[SerializeField]private float timerShot=0;
	protected override void Awake(){
		idleState = new EnemyArcIdle (this,stateMachine,"Idle",this);
		moveState = new EnemyArcMove (this,stateMachine,"Move",this);
		shotState = new EnemyArcShot (this,stateMachine,"Shoot",this);
	}
	void OnEnable(){
		stateMachine.FirshState (idleState);
	}
	protected override void FixedUpdate ()
	{
		base.FixedUpdate ();
		if(!CheckReadyShot())
		timerShot += Time.fixedDeltaTime;
	}
	public virtual bool CheckReadyShot(){
		return timerShot > dataShot.timeDelay;
	}
	public virtual void Shot(){
		timerShot =0;
		shot.ShootBullet (transform.position);
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadAbilityShot ();
	}
	private void LoadAbilityShot(){
		if (shot != null)
			return;
		shot = transform.parent.parent.GetComponentInChildren<AbilityShot> ();
		Debug.LogWarning ("Add Shot Ability", gameObject);
	}
}
