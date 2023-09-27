using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCircularPlayer : AbilityCircular {
	protected override void ResetValue ()
	{
		base.ResetValue ();
		speed = 1.5f;
	}
	public bool test;
	protected override void SetCenterPosition ()
	{
		centerPosition = transform;
	}
	void Update(){
		if (test) {
			InstantiatePrab ();
			test = false;
		}
	}
	protected override void Start ()
	{
		base.Start ();
		gameObject.SetActive (false);
	}
}
