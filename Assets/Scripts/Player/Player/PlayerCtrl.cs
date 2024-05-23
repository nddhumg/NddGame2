using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : GameObjCtrl {
	private static PlayerCtrl instance;
	public static PlayerCtrl Instance{
		get{
			return instance;
		}
	}
	protected override void LoadSingleton() {
		if (PlayerCtrl.instance != null) {
			Debug.LogError("Only 1 InputManager allow to exist");

		}
		PlayerCtrl.instance = this;
	}

	[SerializeField]protected PhysicsPlayer physicsPlayer;
	[SerializeField]protected DamageReceiverPlayer damageReceiver;
	[SerializeField]protected AnimationPlayer animationPlayer;
	[SerializeField]protected MovingPlayer movingPlayer;
	[SerializeField]protected PlayerSO playerSO;
	[SerializeField]protected SOStat statsSO;
	[SerializeField]protected AbilityDashPlayer dashPlayer;
	[SerializeField]protected AbilityShotPlayer shotPlayer;
	[SerializeField]protected LevelPlayer level;
	[SerializeField]protected AttributesPlayer attributes;
	[SerializeField]protected AbilityPlayerCtrl abilityCtrl;
	public AbilityPlayerCtrl AbilityCtrl{
		get{
			return abilityCtrl;
		}
	}
	public LevelPlayer LevelPlayer{
		get{
			return level;
		}
	}
	public AttributesPlayer AttributesPlayer{
		get{
			return attributes;
		}
	}
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
	public SOStat StatsSO{
		get{
			return statsSO;
		}
	}
	public DamageReceiverPlayer DamageReceiver{
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
		LoadPhysicsPlayer ();
		LoadAnimationPlayer ();
		LoadMovingPlayer ();
		LoadPlayerSO ();
		LoadDamageReceiver ();
		LoadDashPlayer ();
		LoadShotPlayer ();
		LoadLevelPlayer ();
		LoadAttributesPlayer ();
		LoadAbilityPlayerCtrl ();
	}
	protected virtual void LoadPlayerSO(){
		if (this.playerSO != null)
			return;
		string resPath = "ScriptableObject/Player/" +	transform.name;
		this.playerSO = Resources.Load<PlayerSO> (resPath);
		Debug.LogWarning (transform.name + " LoadPlayerSO " + resPath, gameObject);
	}
	protected virtual void LoadAbilityPlayerCtrl(){
		if (this.abilityCtrl != null)
			return;
		this.abilityCtrl= GetComponentInChildren<AbilityPlayerCtrl>();
		Debug.Log ("Add AbilityCtrl", gameObject);
	}
	protected virtual void LoadLevelPlayer(){
		if (this.level != null)
			return;
		this.level= GetComponentInChildren<LevelPlayer>();
		Debug.Log ("Add LevelPlayer", gameObject);
	}
	protected virtual void LoadAttributesPlayer(){
		if (this.attributes != null)
			return;
		this.attributes= GetComponentInChildren<AttributesPlayer>();
		Debug.Log ("Add AttributesPlayer", gameObject);
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
		this.damageReceiver= GetComponentInChildren<DamageReceiverPlayer>();
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
