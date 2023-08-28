using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcCtrl : EnemyCtrl {
	[SerializeField] protected EnemyArcSO enemyArcSO;
	[SerializeField] protected AbilityShotEnemy shotEnemy;
	[SerializeField] protected AnimationEnemyArc animationEnemyArc;
	public EnemyArcSO EnemyArcSO{
		get{
			return enemyArcSO;
		}
	}
	public AbilityShotEnemy ShotEnemy{
		get{
			return shotEnemy;
		}
	}
	public AnimationEnemyArc AnimationEnemyArc{
		get{
			return animationEnemyArc;
		}
	}
	protected override void LoadComponent(){
		base.LoadComponent ();
		this.ConvertEnemyArcSO ();
		this.ConvertdAnimationEnemyArc ();
		this.LoadShotEnemy ();
	}
	protected virtual void LoadShotEnemy(){
		if (this.shotEnemy != null)
			return;
		this.shotEnemy = GetComponentInChildren<AbilityShotEnemy> ();
		Debug.LogWarning ("Add ShotEnemy", gameObject);
	}
	protected virtual void ConvertEnemyArcSO(){
		if (this.enemyArcSO != null)
			return;
		enemyArcSO = enemySO as EnemyArcSO;
		Debug.LogWarning ("EnemySO convert to EnemyArcSO", gameObject);
	}
	protected virtual void ConvertdAnimationEnemyArc(){
		if (this.animationEnemyArc != null)
			return;
		animationEnemyArc = animationEnemy as AnimationEnemyArc;
		Debug.LogWarning ("AnimationEnemy convert to AnimationEnemyArc", gameObject);
	}

}
