using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SoundItemAble : NddBehaviour {
	[SerializeField] protected AudioSource audioFx;
	protected override void Start(){
		base.Start ();
		audioFx.Play ();
	}

}
