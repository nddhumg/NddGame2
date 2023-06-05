using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : NddBehaviour {

	[SerializeField]protected float timeDestroy = 3f;
	[SerializeField]protected float time = 0f;

	void Update ()
	{
		this.DestroyObjByTime ();
	}
	public virtual void DestroyObj(){
		time = 0f;
		Destroy(transform.parent);
	}

	protected virtual bool CanDesTroy(){
		time += Time.deltaTime;
		if (time > timeDestroy)
			return true;
		return false;
	}
	protected virtual void DestroyObjByTime(){
		if (!CanDesTroy ())
			return;
		this.DestroyObj ();
	}

}
