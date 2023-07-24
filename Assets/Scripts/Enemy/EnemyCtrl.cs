using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : NddBehaviour {
	[SerializeField] protected Rigidbody2D rig2d;
	[SerializeField] protected DestroyEnemy destroyEnemy;
	[SerializeField] protected DamageSenderEnemy damageSenderEnemy;
	[SerializeField] protected DamageReceiverEnemy damageReceiverEnemy;
	[SerializeField] protected EnemyFollow enemyFollow;
	[SerializeField] protected EnemySO enemySO;
	[SerializeField] protected EnemyArcSO enemyArcSO;
	public EnemySO EnemySO{
		get{
			return enemySO;
		}
	}
	public EnemyArcSO EnemyArcSO{
		get{
			return enemyArcSO;
		}
	}
	public EnemyFollow EnemyFollow{
		get{
			return enemyFollow;
		}
	}
	public DamageSenderEnemy DamageSenderEnemy{
		get{
			return damageSenderEnemy;
		}
	}
	public DamageReceiverEnemy DamageReceiverEnemy{
		get{
			return damageReceiverEnemy;
		}
	}
	public DestroyEnemy DestroyEnemy{
		get{
			return destroyEnemy;
		}
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadDestroyEnemy ();
		this.LoadEnemySO ();
		this.LoadDamageSenderEnemy ();
		this.LoadDamageReceiverEnemy ();
		this.LoadEnemyFollow ();
	}
	protected virtual void LoadEnemyFollow(){
		if (this.enemyFollow != null)
			return;
		this.enemyFollow= GetComponentInChildren<EnemyFollow>();
		Debug.LogWarning ("Add EnemyFollow", gameObject);
	}
	protected virtual void LoadDamageReceiverEnemy(){
		if (this.damageReceiverEnemy != null)
			return;
		this.damageReceiverEnemy= GetComponentInChildren<DamageReceiverEnemy>();
		Debug.LogWarning ("Add DamageReceiverEnemy", gameObject);
	}
	protected virtual void LoadDamageSenderEnemy(){
		if (this.damageSenderEnemy != null)
			return;
		this.damageSenderEnemy= GetComponentInChildren<DamageSenderEnemy>();
		Debug.LogWarning ("Add DamageSenderEnemy", gameObject);
	}
	protected virtual void LoadDestroyEnemy(){
		if (this.destroyEnemy != null)
			return;
		this.destroyEnemy= GetComponentInChildren<DestroyEnemy>();
		Debug.LogWarning ("Add DestroyEnemy", gameObject);
	}
	protected virtual void LoadEnemySO(){
		if (this.enemySO != null)
			return;
		string resPath = "ScriptableObject/Enemy/EnemyColliderCapsule/" +	transform.name;
		this.enemySO = Resources.Load<EnemySO> (resPath);
		enemyArcSO = Resources.Load<EnemyArcSO> (resPath);
		Debug.LogWarning (transform.name + " LoadEnemySO " + resPath, gameObject);
	}

}
