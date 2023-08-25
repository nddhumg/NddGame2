using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyArc : DestroyEnemy {
	public override void DestroyObject ()
	{
		base.DestroyObject ();
		SpawnEnemy.Instance.ReductTheNumberofEnemyArc ();
	}
}
