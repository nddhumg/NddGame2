using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityCustomizeShooting : AbilityCustomizableObject {
	protected AbilityShot abilityShot;

	public AbilityCustomizeShooting(AbilityShot shot){
		abilityShot = shot;
	}


}
