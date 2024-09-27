using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DamagePopUp : TextMeshBase {
	public void SetUp(float damage)
	{
		textMesh.text = "-" + damage.ToString ();
		textMesh.color = Color.red;
	}

	public void SetUp(float damage,Color color)
	{
		textMesh.text = "-" + damage.ToString ();
		textMesh.color = color	;
	}

}
