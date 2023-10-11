using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBlastEndState : StateMachineBehaviour {
	public override void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (stateInfo.normalizedTime >= 1f) {
			SpawnFx.Instance.DesTroyPrefabs (animator.transform.parent.parent);
		}
	}

}
