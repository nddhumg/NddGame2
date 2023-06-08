using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : NddBehaviour {
	[SerializeField]protected Animator ani;

	protected override void LoadComponent(){
		this.LoadAnimatorPlayer ();
	}
	protected virtual void LoadAnimatorPlayer(){
		if (this.ani != null)
			return;
		Transform model = transform.parent.Find ("Model");
		this.ani= model.GetComponentInChildren<Animator>();
		Debug.Log ("Add AnimatorPlayer", gameObject);
	}
	public virtual void SetAnimationRuning(bool isRuning){
		ani.SetBool ("IsRuning", isRuning);
	}
	public virtual void SetAnimationAttackIdle(bool isAttackIdle){
		ani.SetBool ("IsAttackIdldle", isAttackIdle);
	}
	public virtual void SetAnimationSurf(bool isSurf){
		ani.SetBool ("IsSurf", isSurf);
	}
}
