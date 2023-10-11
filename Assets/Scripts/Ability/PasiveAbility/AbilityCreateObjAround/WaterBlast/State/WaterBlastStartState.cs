using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBlastStartState : StateMachineBehaviour {
	[SerializeField]protected float timer = 0;
	[SerializeField]protected float duration = 5f;
	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
		timer += Time.deltaTime;
		if (timer >= duration) {
			animator.SetTrigger ("EndWaterTornado");
			timer = 0;
		}
	}
}
