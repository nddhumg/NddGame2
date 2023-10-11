using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWaterTornado : MoveInTheDirection {
	void OnEnable(){
		SetDirection ();
	}
	protected override void ResetValue ()
	{
		base.ResetValue ();
		speed = 3f;
	}
	protected override void Moving(){
		transform.parent.position += direction * Time.fixedDeltaTime;;
	}
	protected override void SetDirection ()
	{
		base.SetDirection ();
		float directionX = Random.Range (-1f, 1f);
		float directionY = Random.Range (-1f, 1f);
		direction = new Vector3 (directionX * speed, directionY * speed, 0);
	}
}
