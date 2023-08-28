using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : GameObjCtrl {
	[SerializeField]protected PhysicsPlayer physicsPlayer;
	[SerializeField]protected DamageReceiver damageReceiver;
	[SerializeField]protected AnimationPlayer animationPlayer;
	[SerializeField]protected MovingPlayer movingPlayer;
	[SerializeField]protected PlayerSO playerSO;
	[SerializeField]protected AbilityDashPlayer dashPlayer;
	[SerializeField]protected AbilityShotPlayer shotPlayer;
	public AbilityDashPlayer DashPlayer{
		get{
			return dashPlayer;
		}
	}
	public AbilityShotPlayer ShotPlayer{
		get{
			return shotPlayer;
		}
	}
	public PlayerSO PlayerSO{
		get{
			return playerSO;
		}
	}
	public DamageReceiver DamageReceiver{
		get{
			return damageReceiver;
		}
	}
	public MovingPlayer MovingPlayer{
		get{
			return movingPlayer;
		}
	}
	public AnimationPlayer AnimationPlayer{
		get{
			return animationPlayer;
		}
	}
	public PhysicsPlayer PhysicsPlayer{
		get{
			return physicsPlayer;
		}
	}
		
	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadPhysicsPlayer ();
		this.LoadAnimationPlayer ();
		this.LoadMovingPlayer ();
		this.LoadPlayerSO ();
		this.LoadDamageReceiver ();
		this.LoadDashPlayer ();
		this.LoadShotPlayer ();
	}
	protected virtual void LoadPlayerSO(){
		if (this.playerSO != null)
			return;
		string resPath = "ScriptableObject/Player/" +	transform.name;
		this.playerSO = Resources.Load<PlayerSO> (resPath);

		Debug.LogWarning (transform.name + " LoadPlayerSO " + resPath, gameObject);
	}

	protected virtual void LoadPhysicsPlayer(){
		if (this.physicsPlayer != null)
			return;
		this.physicsPlayer= GetComponent<PhysicsPlayer>();
		Debug.Log ("Add PhysicsPlayer", gameObject);
	}
	protected virtual void LoadShotPlayer(){
		if (this.shotPlayer != null)
			return;
		this.shotPlayer= GetComponentInChildren<AbilityShotPlayer>();
		Debug.Log ("Add ShotPlayer", gameObject);
	}
	protected virtual void LoadDashPlayer(){
		if (this.dashPlayer != null)
			return;
		this.dashPlayer= GetComponentInChildren<AbilityDashPlayer>();
		Debug.Log ("Add DashPlayer", gameObject);
	}
	protected virtual void LoadDamageReceiver(){
		if (this.damageReceiver != null)
			return;
		this.damageReceiver= GetComponentInChildren<DamageReceiver>();
		Debug.Log ("Add DamageReceiver", gameObject);
	}
	protected virtual void LoadMovingPlayer(){
		if (this.movingPlayer != null)
			return;
		this.movingPlayer= GetComponentInChildren<MovingPlayer>();
		Debug.Log ("Add MovingPlayer", gameObject);
	}
	protected virtual void LoadAnimationPlayer(){
		if (this.animationPlayer != null)
			return;
		this.animationPlayer= GetComponentInChildren<AnimationPlayer>();
		Debug.Log ("Add AnimationPlayer", gameObject);
	}


}
