using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityClone : PassiveAbility {
	public virtual void StartCloneAbility (int numberOfClone,GameObject objectClone,Vector3 locationClone,Quaternion rotClone){
		for (int i = 0; i < numberOfClone; i++) {
			SpawnClone (objectClone, locationClone,rotClone);
			DistanceXWhenClone (0.5f,ref locationClone.x);
		}
	}
	public virtual void StartCloneAbility (int numberOfClone,string objectNamClone,Vector3 locationClone,Quaternion rotClone){
		for (int i = 0; i < numberOfClone; i++) {
			SpawnClone (objectNamClone, locationClone,rotClone);
			DistanceXWhenClone (0.5f,ref locationClone.x);
		}
	}
	protected virtual void SpawnClone(GameObject objectClone,Vector3 locationClone,Quaternion rotClone){
		GameObject cloneGameObj = Instantiate (objectClone,locationClone,rotClone);
		cloneGameObj.SetActive (true);
	}
	protected virtual void SpawnClone(string objectNameClone,Vector3 locationClone,Quaternion rotClone){
		//Abstract Clone by string
	}
	protected virtual void DistanceXWhenClone(float distanceX,ref float locationX){
		locationX += distanceX;
	}
}
