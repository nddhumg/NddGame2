using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopUp : TextMeshBase {
	public void SetUp(float damage)
	{
		textMesh.text = damage.ToString ();
	}
}
