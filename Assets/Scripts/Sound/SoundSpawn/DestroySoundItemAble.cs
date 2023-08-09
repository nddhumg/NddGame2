using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySoundItemAble : DestroyByTime {

	public override void DestroyObject (){
		SpawnerExp.Instance.DesTroyPrefabs (transform.parent);
	}
}
