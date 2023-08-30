using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DebugGame : MonoBehaviour {
	public bool debug ;
	// Update is called once per frame
	void Update () {
		if (debug) {
			StartDebug ();
			debug = false;
		}
	}
	protected abstract void StartDebug ();
}
