using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BaseText : NddBehaviour {
	[SerializeField] protected Text text;
	protected override void LoadComponent(){
		if (this.text != null)
			return;
		this.text= GetComponentInChildren<Text>();
		Debug.Log ("Add Text", gameObject);
	}
}
