using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarriorCtrl : EnemyCtrl {
	[SerializeField] protected EnemyWarriorSO enemyWarriorSO;
	[SerializeField] protected DamageSenderEnemy damageSenderEnemy;
	public EnemyWarriorSO EnemyWarriorSO{
		get{
			return enemyWarriorSO;
		}
	}
	public DamageSenderEnemy DamageSenderEnemy{
		get{
			return damageSenderEnemy;
		}
	}
	protected override void LoadComponent(){
		base.LoadComponent ();
		this.ConvertEnemyWarriorSO ();
		this.LoadDamageSenderEnemy ();
	}
	protected virtual void LoadDamageSenderEnemy(){
		if (this.damageSenderEnemy != null)
			return;
		this.damageSenderEnemy= GetComponentInChildren<DamageSenderEnemy>();
		Debug.LogWarning ("Add DamageSenderEnemy", gameObject);
	}
	protected virtual void ConvertEnemyWarriorSO(){
		if (this.enemyWarriorSO != null)
			return;
		enemyWarriorSO = enemySO as EnemyWarriorSO;
		Debug.LogWarning ("EnemySO convert to EnemyWarriorSO", gameObject);
	}

}
