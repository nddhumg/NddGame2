using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtrl : EnemyCtrl {
	[Header("Boss Ctrl")]
	[SerializeField] protected BossSO bossSO;
	[SerializeField] private DamageReceiverBoss damageReceiverBoss;
	public BossSO BossSO{
		get{
			return bossSO;
		}
	}
	public DamageReceiverBoss DamageReceiverBoss{
		get{
			return damageReceiverBoss;
		}
	}
	protected override void LoadComponent(){
		base.LoadComponent ();
		this.ConvertBossSO ();
		ConvertDamageReceiverBoss ();
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
	protected virtual void ConvertDamageReceiverBoss(){
		if (this.damageReceiverBoss != null)
			return;
		damageReceiverBoss = damageReceiverEnemy as DamageReceiverBoss;
		Debug.LogWarning ("DamageReceiverEnemy convert to DamageReceiverBoss", gameObject);
	}
}
