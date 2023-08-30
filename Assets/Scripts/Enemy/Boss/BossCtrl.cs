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
	protected override void ResetValue ()
	{
		base.ResetValue ();
		folderNameSO = "ScriptableObject/Enemy/Boss/";
	}
	protected virtual void ConvertBossSO(){
		if (this.bossSO != null)
			return;
		bossSO = enemySO as BossSO;
		Debug.LogWarning ("EnemySO convert to BossSO", gameObject);
	}

}
