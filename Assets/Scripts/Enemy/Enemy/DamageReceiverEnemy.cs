﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
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
	protected override void ResetValueComponent ()
	{
		base.ResetValueComponent ();
		this.hpMax = enemyCtrl.Stats.GetValueStat(StatsName.Hp);	
	}
	protected override void OnDead(){
		this.DropItemWhenDead ();
		ResetHp ();
		enemyCtrl?.DestroyEnemy?.DestroyObject ();
	}
	public virtual void DropItemWhenDead(){
		DropExp ();
		DropItem ();
	}
	protected virtual void DropExp(){
		List<DropExpRate> listExpDrop = enemyCtrl.EnemySO.listDropExp;
		string nameExpDrop = GetNameDrop (listExpDrop);
		if (nameExpDrop == null)
			return;
		SpawnItem.Instance.Spawn (nameExpDrop, transform.position, Quaternion.identity);
	}
	protected virtual void DropItem(){
		List<DropItemRate> listItemDrop = enemyCtrl.EnemySO.ListDropItem;
		string nameItemDrop = GetNameDrop (listItemDrop);
		if (nameItemDrop == null)
			return;
		SpawnItem.Instance.Spawn (nameItemDrop, transform.position, Quaternion.identity);
	}
	protected virtual string GetNameDrop<T>(List<T> dropList) where T : IDropItem
	{
		try{
			float rand = UnityEngine.Random.Range (0f, 1f);
			float temp = 0;
			foreach (T percentageDrop in dropList) {
				temp += percentageDrop.GetPercentage();
				if (temp >= rand){
					return percentageDrop.GetName ();
				}
			}
			return null;
		}
		catch{
			Debug.LogWarning ("Error dont get name drop");
			return null;
		}
	}

}
