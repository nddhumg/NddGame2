using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFx : DestroyByTime {
	public override void DestroyObj ()
	{
		timer = 0f;
		SpawnFx.Instance.DesTroyPrefabs (transform.parent.transform);
	}

}
