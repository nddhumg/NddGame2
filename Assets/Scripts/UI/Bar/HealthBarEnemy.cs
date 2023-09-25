using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarEnemy : BarUI {
	[SerializeField]protected EnemyCtrl enemyCtrl;
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadEnemyCtrl ();
	}
	protected virtual void LoadEnemyCtrl(){
		if (this.enemyCtrl != null)
				return;
		this.enemyCtrl= transform.parent.parent.GetComponent<EnemyCtrl>();
		Debug.LogWarning ("Add EnemyCtrl", gameObject);
	}
	protected override void GetValue(){
		valueCurrent = enemyCtrl.DamageReceiverEnemy.Hp;
		valueMax = enemyCtrl.DamageReceiverEnemy.HpMax;
	}
}
