using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : DestroyByTime {
	public override void DestroyObj ()
	{
		time = 0f;
		SpawnBullet.Instance.DesTroyPrefabs (transform.parent.transform);
	}

}
