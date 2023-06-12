using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CapsuleCollider2D))]
public class CollisionEnemy : NddBehaviour {
	[Header("ColliderEnemy")]
	[SerializeField] protected EnemyCtrl enemyCtrl;
	[SerializeField] protected CapsuleCollider2D capsuleCollider2D;

	protected override void LoadComponent(){
		this.LoadEnemyCtrl ();
		base.LoadComponent ();
		this.LoadCapsuleCollider2D ();
	}
	protected virtual void LoadEnemyCtrl(){
		if (this.enemyCtrl != null)
			return;
		this.enemyCtrl= transform.parent.GetComponent<EnemyCtrl>();
		Debug.Log ("Add  EnemyCtrl", gameObject);
	}
	protected virtual void LoadCapsuleCollider2D(){
		if(this.capsuleCollider2D != null)
			return;
		this.capsuleCollider2D = GetComponent<CapsuleCollider2D> ();
		this.capsuleCollider2D.isTrigger = false;
		this.capsuleCollider2D.offset = enemyCtrl.EnemySO.offsetCollider;
		this.capsuleCollider2D.size = enemyCtrl.EnemySO.sizeCollider;
		Debug.Log("Add BoxCollider2D",gameObject);
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.transform.CompareTag ("Enemy"))
			return;
		enemyCtrl.DamageSenderEnemy.Send (col.transform);
	}
}
