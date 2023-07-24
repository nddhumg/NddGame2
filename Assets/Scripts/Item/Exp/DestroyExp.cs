using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExp : NddBehaviour {

	public virtual void DestroyObj (){
		SpawnerExp.Instance.DesTroyPrefabs (transform.parent);
	}
}
