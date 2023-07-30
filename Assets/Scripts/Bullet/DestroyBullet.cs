using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : DestroyByTime {
	protected override void ToDestroy ()
	{
		SpawnBullet.Instance.DesTroyPrefabs (transform.parent.transform);
	}
	protected override void ResetValue ()
	{
		base.ResetValue ();
		this.timeDestroy = 5f;	
	}

}
