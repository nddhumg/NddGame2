using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : NddBehaviour {
	public Animator anim;
	protected StateMachine stateMachine = new StateMachine ();

	protected virtual void Update(){
		stateMachine.currentState.LogicUpdate ();
	}
	protected virtual void FixedUpdate(){
		stateMachine.currentState.PhySicsUpdate ();
	}
	public void AnimationFinishTrigger(){
		stateMachine.currentState.AnimationFinishTrigger();
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadAnimator ();
	}
	private void LoadAnimator(){
		if(anim != null)
			return;
		anim = transform.GetComponent<Animator>();
		Debug.LogWarning("Add Animator",gameObject);
	}
}
