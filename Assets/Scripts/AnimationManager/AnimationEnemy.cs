using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnemy : AnimationAbstract {
	
	public virtual void SetAnimationAttack(bool isAttack){
		ani.SetBool ("IsAttack", isAttack);
	}

}
