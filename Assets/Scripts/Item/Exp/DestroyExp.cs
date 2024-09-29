using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExp : DestroyObj {

	public override void DestroyObject (){
		SpawnItem.Instance.DesTroyPrefabs (transform.parent);
	}
}
