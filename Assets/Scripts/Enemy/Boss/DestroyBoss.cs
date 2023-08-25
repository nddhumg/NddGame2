using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoss : DestroyEnemy {
	public override void DestroyObject (){
		SpawnBoss.Instance.DesTroyPrefabs (transform.parent);
	}
}
