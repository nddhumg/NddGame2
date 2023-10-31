using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZone : MonoBehaviour {
	public void SetUp(float radious){
		transform.localScale = new Vector3 (radious, radious, 1);
	}
}
