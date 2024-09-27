using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamageReceiverFinalBoss : DamageReceiverBoss {
	[SerializeField] private GameObject UIFinal;
	protected override void OnDead ()
	{
		base.OnDead ();
		UIFinal.SetActive (true);
		MainPlay.Instance.PauseGame ();
	} 
}
