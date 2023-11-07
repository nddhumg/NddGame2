using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMagnerExp : ActivateMagnerItem {
	void OnEnable(){
		PickUpAbleExpMagnet.OnPickUp += ActivateMagner;
	}
	protected override void OnDisable ()
	{
		base.OnDisable ();
		PickUpAbleExpMagnet.OnPickUp -= ActivateMagner;
	}

}
