using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextBase : NddBehaviour {
	[SerializeField] protected Text text;
	protected override void LoadComponent(){
		LoadText ();
	}
	protected virtual void LoadText(){
		if (this.text != null)
			return;
		this.text= GetComponentInChildren<Text>();
		Debug.Log ("Add Text", gameObject);
	}
}
