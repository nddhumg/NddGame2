using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : DestroyByTime {
	public override void DestroyObj ()
	{
		timer = 0f;
		SpawnBullet.Instance.DesTroyPrefabs (transform.parent.transform);

	}
	protected override void ResetValue ()
	{
		base.ResetValue ();
		this.timeDestroy = 5f;	
	}

}
