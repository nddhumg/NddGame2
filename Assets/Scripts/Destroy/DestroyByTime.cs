using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : DestroyObj {

	[SerializeField]protected float timeDestroy = 3f;
	[SerializeField]protected float timer = 0f;

	void FixedUpdate()
	{
		this.DestroyObjByTime ();
	}
	public override void DestroyObject(){
		timer = 0f;
		ToDestroy ();
	}
	protected virtual void ToDestroy(){
		Destroy(transform.parent);
	}
	protected virtual bool CanDesTroy(){
		timer += Time.fixedDeltaTime;
		if (timer > timeDestroy)
			return true;
		return false;
	}
	protected virtual void DestroyObjByTime(){
		if (!CanDesTroy ())
			return;
		this.DestroyObject ();
	}

}
