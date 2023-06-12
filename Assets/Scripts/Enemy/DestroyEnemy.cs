using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : NddBehaviour {
	public virtual void DestroyObj ()
	{
		SpawnEnemy.Instance.ReductTheNumberofEnemy ();
		SpawnEnemy.Instance.DesTroyPrefabs (transform.parent.transform);
	}
}
