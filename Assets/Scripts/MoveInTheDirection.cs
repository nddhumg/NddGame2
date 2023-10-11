	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class MoveInTheDirection : NddBehaviour {
	
	[SerializeField]protected float speed = 2f;
	[SerializeField]protected Vector3 direction= new Vector3 (1f, 1f, 0f);
	
	void FixedUpdate ()
	{
		this.Moving ();
	}

	protected virtual void Moving(){
		transform.parent.position += direction.normalized * Time.fixedDeltaTime * speed;
	}	
	protected virtual void SetDirection(){
		//Abstract
	}
}	
	
