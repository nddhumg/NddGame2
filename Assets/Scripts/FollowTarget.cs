using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FollowTarget : NddBehaviour {
	[Header("FollowTarget")]
	[SerializeField]protected Transform target;
	[SerializeField]protected float speedFollow = 0.4f;

	protected override void LoadComponent ()
	{
		this.LoadTarget ();
	}
	void Update(){
		this.Follow();
	}
	protected abstract void LoadTarget ();
	protected virtual void Follow(){
		if (target == null) {
			Debug.LogError ("Not Obj Target",gameObject);
			return;
		}

		transform.position = Vector3.Lerp (transform.position, this.target.position, this.speedFollow * Time.deltaTime);
	}
}
