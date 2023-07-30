using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcCtrl : EnemyCtrl {
	[SerializeField] protected EnemyArcSO enemyArcSO;

	public EnemyArcSO EnemyArcSO{
		get{
			return enemyArcSO;
		}
	}
	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadEnemyArcSO ();
	}
	protected virtual void LoadEnemyArcSO(){
		if (this.enemyArcSO != null)
			return;
		enemyArcSO = enemySO as EnemyArcSO;
		Debug.LogWarning ("EnemySO convert to EnemyArcSO", gameObject);
	}
}
