﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
public class DamageSenderEnemy : DamageSender {
	[SerializeField] protected EnemyWarriorCtrl enemyWarriorCtrl;
	[SerializeField] protected CircleCollider2D circleCollider2D;
	[SerializeField] protected float timer =1f;
	[SerializeField] protected float timeDelayAttack = 1f;
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadEnemyWarriorCtrl ();
		this.LoadCircleCollider2D();
	}
	protected virtual void FixedUpdate(){
		timer += Time.fixedDeltaTime;
	}
	protected virtual void LoadCircleCollider2D(){
		if (this.circleCollider2D != null)
			return;
		this.circleCollider2D= GetComponent<CircleCollider2D>();
		circleCollider2D.offset = enemyWarriorCtrl.EnemyWarriorSO.offsetZoneAttack;
		circleCollider2D.radius = enemyWarriorCtrl.EnemyWarriorSO.attackRange;
		circleCollider2D.isTrigger = true;
		Debug.LogWarning ("Add CircleCollider2D", gameObject);
	}
	protected virtual void LoadEnemyWarriorCtrl(){
		if (this.enemyWarriorCtrl != null)
			return;
		this.enemyWarriorCtrl= transform.parent.GetComponent<EnemyWarriorCtrl>();
		Debug.LogWarning ("Add EnemyCtrl", gameObject);
	}
	protected override void Send (DamageReceiver receiver)
	{
		if (timer < timeDelayAttack)
			return;
		base.Send (receiver);
		timer = 0;
	}
	protected override void ResetValue ()
	{
		base.ResetValue ();
		this.damage = enemyWarriorCtrl.EnemyWarriorSO.damage;
	}
	protected virtual void OnTriggerStay2D(Collider2D col){
		if (col.isTrigger)
			return;
		if (col.transform.parent.CompareTag ("Enemy"))
			return;
		Send (col.transform.parent);
	}
}
