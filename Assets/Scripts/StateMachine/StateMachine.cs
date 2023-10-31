using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine  {

	public BaseState currentState;

	public void FirshState(BaseState state){
		currentState = state;
		currentState.Enter ();
	}
	public void ChangeState(BaseState newState){
		currentState.Exit ();
		currentState = newState;
		currentState.Enter ();
	}
	public void AnimationFinishTrigger(){
		currentState.AnimationFinishTrigger ();
	}
}
