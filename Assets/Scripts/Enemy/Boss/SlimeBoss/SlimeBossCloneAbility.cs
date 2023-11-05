using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBossCloneAbility : AbilityClone {
	[Header("SlimeBossCloneAbility")]
	[SerializeField] protected EnemyName enemyClone = EnemyName.SlimeClone;
	[SerializeField] protected int numberOfSpawnClone = 2;

	protected override GameObject SpawnClone(string objectNameClone,Vector3 locationClone,Quaternion rotClone){
		GameObject cloneGameObj = SpawnBoss.Instance.Spawn (objectNameClone, locationClone, rotClone)?.gameObject;
		cloneGameObj.SetActive (true);
		return cloneGameObj;
	}
	public virtual void AbilityCloneSlimeBoss(){
		StartCloneAbility(numberOfSpawnClone,enemyClone.ToString(),transform.position,Quaternion.identity);
	}

}
