using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : GameObjCtrl {
	[SerializeField] protected DestroyEnemy destroyEnemy;
	[SerializeField] protected DamageReceiverEnemy damageReceiverEnemy;
	[SerializeField] protected Animator ani;
	[SerializeField] protected EnemySO enemySO;
	[SerializeField] protected SOStat stats;
	[SerializeField] protected EnemyStateManager stateManager;
	[SerializeField] protected string folderNameSO = "ScriptableObject/Enemy/";

	public EnemySO EnemySO{
		get{
			return enemySO;
		}
	}
	public EnemyStateManager StateManager{
		get{
			return stateManager;
		}
	}
	public SOStat Stats{
		get{
			return stats;
		}
	}
	public Animator Animator{
		get{
			return ani;
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
		this.LoadDamageReceiverEnemy ();
		LoadEnemyStateManager ();
		LoadAnimator ();
	}
	protected virtual void LoadAnimator(){
		if (this.ani != null)
			return;
		this.ani= GetComponentInChildren<Animator>();
		Debug.LogWarning ("Add Animator", gameObject);
	}
	protected virtual void LoadDamageReceiverEnemy(){
		if (this.damageReceiverEnemy != null)
			return;
		this.damageReceiverEnemy= GetComponentInChildren<DamageReceiverEnemy>();
		Debug.LogWarning ("Add DamageReceiverEnemy", gameObject);
	}

	protected virtual void LoadDestroyEnemy(){
		if (this.destroyEnemy != null)
			return;
		this.destroyEnemy= GetComponentInChildren<DestroyEnemy>();
		Debug.LogWarning ("Add DestroyEnemy", gameObject);
	}

	protected virtual void LoadEnemyStateManager(){
		if (this.stateManager != null)
			return;
		this.stateManager= GetComponentInChildren<EnemyStateManager>();
		Debug.LogWarning ("Add EnemyStateManager", gameObject);
	}

	protected virtual void LoadEnemySO(){
		if (this.enemySO != null)
			return;
		string resPath = folderNameSO +	transform.name;
		enemySO = Resources.Load<EnemySO> (resPath);
		Debug.LogWarning (transform.name + " LoadEnemySO " + resPath, gameObject);
	}

}
