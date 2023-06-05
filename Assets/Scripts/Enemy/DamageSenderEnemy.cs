using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSenderEnemy : DamageSender {
	[SerializeField] protected EnemyCtrl enemyCtrl;
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadEnemyCtrl ();
	}
	protected virtual void LoadEnemyCtrl(){
		if (this.enemyCtrl != null)
			return;
		this.enemyCtrl= transform.parent.GetComponent<EnemyCtrl>();
		Debug.Log ("Add EnemyCtrl", gameObject);
	}
	protected override void ResetValue ()
	{
		base.ResetValue ();
		this.damage = enemyCtrl.EnemySO.damage;
	}

}
