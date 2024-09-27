using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiverGoblingKingBoss : DamageReceiverBoss {
	private IChangeStateDie changeStateDead;
	protected override void Start ()
	{
		base.Start ();
		changeStateDead = enemyCtrl.StateManager.GetComponent<IChangeStateDie> ();
	}
	protected override void OnDead ()
	{
		changeStateDead.ChangeStateDead ();
	} 
}
