using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : GameObjCtrl {
	[SerializeField] protected DestroyEnemy destroyEnemy;
	[SerializeField] protected DamageReceiverEnemy damageReceiverEnemy;
	[SerializeField] protected EnemyFollow enemyFollow;
	[SerializeField] protected AnimationEnemy animationEnemy;
	[SerializeField] protected EnemySO enemySO;
	[SerializeField] protected string folderNameSO = "ScriptableObject/Enemy/";

	public EnemySO EnemySO{
		get{
			return enemySO;
		}
	}
	public AnimationEnemy AnimationEnemy{
		get{
			return animationEnemy;
		}
	}
	public EnemyFollow EnemyFollow{
		get{
			return enemyFollow;
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
		this.LoadEnemyFollow ();
		this.LoadAnimationEnemy ();
	}
	protected virtual void LoadAnimationEnemy(){
		if (this.animationEnemy != null)
			return;
		this.animationEnemy= GetComponentInChildren<AnimationEnemy>();
		Debug.LogWarning ("Add AnimationEnemy", gameObject);
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

	protected virtual void LoadDestroyEnemy(){
		if (this.destroyEnemy != null)
			return;
		this.destroyEnemy= GetComponentInChildren<DestroyEnemy>();
		Debug.LogWarning ("Add DestroyEnemy", gameObject);
	}

	protected virtual void LoadEnemySO(){
		if (this.enemySO != null)
			return;
		string resPath = folderNameSO +	transform.name;
		enemySO = Resources.Load<EnemySO> (resPath);
		Debug.LogWarning (transform.name + " LoadEnemySO " + resPath, gameObject);
	}

}
