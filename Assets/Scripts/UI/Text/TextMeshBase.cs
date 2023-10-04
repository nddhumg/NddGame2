using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMeshBase : NddBehaviour {
	[SerializeField] protected TextMesh textMesh;
	protected override void LoadComponent(){
		LoadTextMesh ();
	}
	protected virtual void LoadTextMesh(){
		if (this.textMesh != null)
			return;
		this.textMesh= GetComponentInChildren<TextMesh>();
		Debug.Log ("Add TextMesh", gameObject);
	}
}
