using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : DestroyObj
{
	public override void DestroyObject (){
		SpawnEnemy.Instance.DesTroyPrefabs (transform.parent);
		
	}
}
