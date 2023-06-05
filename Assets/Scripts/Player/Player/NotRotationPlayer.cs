using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotRotationPlayer : NddBehaviour{
	void Update(){
		transform.parent.rotation = Quaternion.Euler(0,0,0);
	}
}
