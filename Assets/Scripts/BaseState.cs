using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState  {
	protected string animBoolName;
	protected bool isAnimationFinished;
	protected float startTime;

	public BaseState (string nameAnimator){
		this.animBoolName = nameAnimator;
	}

	public virtual void Enter(){
		startTime = Time.time;
		isAnimationFinished = false;
	}
	public virtual void Exit(){
	}
	public virtual void LogicUpdate (){
	}
	public virtual void PhySicsUpdate (){

	} 
	public virtual void AnimationFinishTrigger(){
		isAnimationFinished = true;
	}
}
