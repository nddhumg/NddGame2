using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnemy : AnimationAbstract {
	public void SetAnimationFollow(bool isFollow){
		ani.SetBool ("IsFollow", isFollow);
	}
}
