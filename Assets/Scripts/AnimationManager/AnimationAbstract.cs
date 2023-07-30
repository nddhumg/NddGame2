using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimationAbstract : NddBehaviour {
	[SerializeField]protected Animator ani;

	protected override void LoadComponent(){
		this.LoadAnimatorPlayer ();
	}
	protected virtual void LoadAnimatorPlayer(){
		if (this.ani != null)
			return;
		this.ani =GetComponent<Animator>();
		Debug.Log ("Add Animator", gameObject);
	}

}
