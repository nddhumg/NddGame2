using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState  {
	protected string animBoolName;
	protected bool isAnimationFinished;
	protected float startTime;

	protected StateMachine stateMachine;
	public BaseState (StateMachine stateMachine,string animBoolName){
		this.stateMachine = stateMachine;
		this.animBoolName = animBoolName;
	}

	public virtual void Enter(){
		startTime = Time.time;
		isAnimationFinished = false;
		DoChecks ();
	}
	public virtual void Exit(){
		
	}
	public virtual void LogicUpdate (){
	}
	public virtual void PhySicsUpdate (){
		DoChecks();
	} 
	public virtual void DoChecks(){
		
	}
	public virtual void AnimationFinishTrigger(){
		isAnimationFinished = true;
	}
}
