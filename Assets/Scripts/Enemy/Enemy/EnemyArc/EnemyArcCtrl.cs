using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcCtrl : EnemyCtrl {
	[SerializeField] protected EnemyArcSO enemyArcSO;
	[SerializeField] protected AbilityShotEnemy shotEnemy;
	public EnemyArcSO EnemyArcSO{
		get{
			return enemyArcSO;
		}
	}
	public AbilityShotEnemy ShotEnemy{
		get{
			return shotEnemy;
		}
	}
	protected override void LoadComponent(){
		base.LoadComponent ();
		this.ConvertEnemyArcSO ();
		this.LoadShotEnemy ();
	}
	protected virtual void LoadShotEnemy(){
		if (this.shotEnemy != null)
			return;
		this.shotEnemy = GetComponentInChildren<AbilityShotEnemy> ();
		Debug.LogWarning ("Add ShotEnemy", gameObject);
	}
	protected virtual void ConvertEnemyArcSO(){
		if (this.enemyArcSO != null)
			return;
		enemyArcSO = enemySO as EnemyArcSO;
		Debug.LogWarning ("EnemySO convert to EnemyArcSO", gameObject);
	}

}
