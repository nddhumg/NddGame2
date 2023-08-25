using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtrl : EnemyCtrl {
	[Header("Boss Ctrl")]
	[SerializeField] protected BossSO bossSO;
	public BossSO BossSO{
		get{
			return bossSO;
		}
	}
	protected override void LoadComponent(){
		base.LoadComponent ();
		this.ConvertBossSO ();
	}
	protected virtual void ConvertBossSO(){
		if (this.bossSO != null)
			return;
		bossSO = enemySO as BossSO;
		Debug.LogWarning ("EnemySO convert to BossSO", gameObject);
	}
	protected override void LoadEnemySO(){
		if (this.enemySO != null)
			return;
		string resPath = "ScriptableObject/Enemy/Boss/" + transform.name;
		enemySO = Resources.Load<EnemySO> (resPath);
		Debug.LogWarning (transform.name + " LoadEnemySO " + resPath, gameObject);
	}
}
