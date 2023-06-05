using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyCtrl : NddBehaviour {
	[SerializeField] protected Rigidbody2D rig2d;
	[SerializeField] protected DestroyEnemy destroyEnemy;
	[SerializeField] protected DamageSenderEnemy damageSenderEnemy;
	[SerializeField] protected DamageReceiverEnemy damageReceiverEnemy;
	[SerializeField] protected EnemySO enemySO;

	public EnemySO EnemySO{
		get{
			return enemySO;
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
		this.LoadRigidbody2D ();
	}
	protected virtual void LoadDamageReceiverEnemy(){
		if (this.damageReceiverEnemy != null)
			return;
		this.damageReceiverEnemy= GetComponentInChildren<DamageReceiverEnemy>();
		Debug.Log ("Add DamageReceiverEnemy", gameObject);
	}
	protected virtual void LoadDamageSenderEnemy(){
		if (this.damageSenderEnemy != null)
			return;
		this.damageSenderEnemy= GetComponentInChildren<DamageSenderEnemy>();
		Debug.Log ("Add DamageSenderEnemy", gameObject);
	}
	protected virtual void LoadDestroyEnemy(){
		if (this.destroyEnemy != null)
			return;
		this.destroyEnemy= GetComponentInChildren<DestroyEnemy>();
		Debug.Log ("Add DestroyEnemy", gameObject);
	}
	protected virtual void LoadEnemySO(){
		if (this.enemySO != null)
			return;
		string resPath = "ScriptableObject/Enemy/EnemyColliderCapsule/" +	transform.name;
		this.enemySO = Resources.Load<EnemySO> (resPath);
		Debug.LogWarning (transform.name + " LoadEnemySO " + resPath, gameObject);
	}
	protected virtual void LoadRigidbody2D(){
		if (this.rig2d != null)
		return;
		rig2d = GetComponent<Rigidbody2D> ();
		this.rig2d.bodyType = RigidbodyType2D.Dynamic;
		this.rig2d.gravityScale = 0f;
		Debug.Log ("Add Rigidbody2DP", gameObject);
	}
}
