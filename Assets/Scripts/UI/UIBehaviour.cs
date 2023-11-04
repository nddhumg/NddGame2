using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBehaviour : NddBehaviour {
	[Header("UI Animation")]
	[SerializeField]protected float speedAnimation = 0.5f;
	[SerializeField]protected Vector3 startAppear = new Vector2(0,500);
	[SerializeField]protected Vector3 endAppear;
	[SerializeField]protected RectTransform rect;
	protected virtual void OnEnable(){
		Appear();
	}
	protected virtual void Appear(){
		
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadRectTransform ();
	}
	private void LoadRectTransform(){
		if (rect != null)
			return;
		rect = transform.GetComponent<RectTransform> ();
		Debug.LogWarning ("Add RectTransform",gameObject);
	}
}
