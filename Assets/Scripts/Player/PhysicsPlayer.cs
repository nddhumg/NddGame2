using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PhysicsPlayer : PhysicsNormalObj {
	
	protected override void SetRigidbody2D(){
		this.rig2d.gravityScale = 0;
		this.rig2d.mass = 10000f;
	}
}
