using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFx : DestroyByTime {
	protected override void ToDestroy ()
	{
		SpawnFx.Instance.DesTroyPrefabs (transform.parent.transform);
	}

}
