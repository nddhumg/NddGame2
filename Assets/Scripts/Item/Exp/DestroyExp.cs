using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExp : DestroyItem {

	public override void DestroyObject (){
		SpawnerExp.Instance.DesTroyPrefabs (transform.parent);
	}
}
