using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiverEnemy : DamageReceiver {
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
		Debug.LogWarning ("Add EnemyCtrl", gameObject);
	}
	protected override void ResetValue ()
	{
		base.ResetValue ();
		this.hpMax = enemyCtrl.EnemySO.hpMax;	
	}
	protected override void OnDead(){
		this.DropItemWhenDead ();
		ResetHp ();
		enemyCtrl?.DestroyEnemy?.DestroyObject ();
	}
	protected virtual void DropItemWhenDead(){
		this.DropExp ();
	}
	protected virtual void DropExp(){
		try{
		float rand = Random.Range (0f, 1f);
		float temp = 0;
		foreach (DropExpRate percentageItemDrop in enemyCtrl.EnemySO.listDropExp) {
			temp += percentageItemDrop.percentage;
			if (temp >= rand){
				string expDropName = percentageItemDrop.expName.ToString ();
				SpawnerExp.Instance.Spawn (expDropName, transform.position, Quaternion.identity);
				return;
			}
		}
		}
		catch{
			Debug.LogWarning ("Error Drop Exp");
		}
	}

}
