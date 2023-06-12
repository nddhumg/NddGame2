using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FollowTarget : NddBehaviour {
	[Header("FollowTarget")]
	[SerializeField]protected Transform target;
	[SerializeField]protected float speedFollow = 1.4f;
	[SerializeField]protected Vector3 direction ;
	[SerializeField] protected bool isFollowing = true;
	public bool IsFollowing{
		get{
			return isFollowing;
		}
	}
	protected override void LoadComponent ()
	{
		this.LoadTarget ();
	}
	void Update(){
		this.Following();
		this.ChangeIsFollowing ();
	}

	protected virtual void Follow(){
		transform.parent.position += direction * speedFollow * Time.deltaTime;
	}
	protected virtual void Following(){
		if (!this.ConditionFollow()) {
			return;
		}
		direction = (target.position - transform.position).normalized;
		Follow ();
	}
	protected virtual bool ConditionFollow(){
		if (target == null) {
			Debug.LogError ("Not Obj Target",gameObject);
			return false;
		}
		if (!isFollowing) {
			return false;
		}
		return true;
	}
	protected virtual void ChangeIsFollowing(){
		// OVERRIDE 
	}
	protected abstract void LoadTarget ();
}
