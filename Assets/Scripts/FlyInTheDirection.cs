	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyInTheDirection : NddBehaviour {
	
	[SerializeField]protected float speedFly = 2f;
	[SerializeField]protected Vector3 direction;
	
	void Update ()
	{
		this.FlyDirection ();
	}

	protected virtual void FlyDirection(){
		transform.parent.position += direction.normalized * Time.deltaTime * speedFly;

	}	

}	
	
