using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreOriginRotationInChild : MonoBehaviour {
	private Quaternion lastParentRotation;
	// Use this for initialization
	void Start () {
		lastParentRotation = transform.parent.parent.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
		transform.parent.localRotation = Quaternion.Inverse (transform.parent.parent.localRotation) * lastParentRotation * transform.parent.localRotation;
		lastParentRotation = transform.parent.parent.localRotation;
	}
}
