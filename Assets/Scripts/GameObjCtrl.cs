using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjCtrl : NddBehaviour {
	[SerializeField]protected GameObject model;
	public GameObject Model{
		get{
			return model;
		}
	}
	protected override void LoadComponent(){
		this.LoadModel ();
	}
	protected virtual void LoadModel(){
		if (this.model != null)
			return;
		this.model = transform.Find ("Model").gameObject;
		Debug.Log ("Add Model", gameObject);
	}
}
