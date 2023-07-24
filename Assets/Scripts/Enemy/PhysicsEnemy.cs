using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEnemy : PhysicsNormalObj {
	
	protected override void SetRigidbody2D(){
		this.rig2d.bodyType = RigidbodyType2D.Dynamic;
		this.rig2d.gravityScale = 0f;
		this.rig2d.mass = 0.5f;
		this.rig2d.constraints = RigidbodyConstraints2D.FreezeRotation;
	}
}
