using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCtrl : NddBehaviour {

	[SerializeField]protected Rigidbody2D rig2D;
	[SerializeField]protected AnimationPlayer animationPlayer;
	[SerializeField]protected MovingPlayer movingPlayer;
	[SerializeField]protected PlayerSO playerSO;

	public PlayerSO PlayerSO{
		get{
			return playerSO;
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


	public Rigidbody2D Rig2D{
		get{
			return rig2D;
		}
	}
		
	protected override void LoadComponent(){
		this.LoadRigidbody2D ();
		this.LoadAnimationPlayer ();
		this.LoadMovingPlayer ();
		this.LoadPlayerSO ();
	}
	protected virtual void LoadPlayerSO(){
		if (this.playerSO != null)
			return;
		string resPath = "ScriptableObject/Player/EnemyColliderCapsule/" +	transform.name;
		this.playerSO = Resources.Load<PlayerSO> (resPath);

		Debug.LogWarning (transform.name + " LoadPlayerSO " + resPath, gameObject);
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

	protected virtual void LoadRigidbody2D(){
		if (this.rig2D != null)
			return;
		this.rig2D= GetComponent<Rigidbody2D>();
		this.SetRigidbody2D ();
		Debug.Log ("Add LoadRigidbody2D", gameObject);
	}
	protected virtual void SetRigidbody2D(){
		this.rig2D.gravityScale = 0; 
	}
}
