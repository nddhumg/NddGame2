using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonBase : NddBehaviour {
	[SerializeField] protected Button button;
	protected override void Start(){
		base.Start ();
		AddOnClickEvent ();
	}
	protected abstract void OnClick ();

	protected virtual void AddOnClickEvent(){
		button.onClick.AddListener (OnClick);
	}

	protected override void LoadComponent(){
		LoadButton();
	}

	protected virtual void LoadButton(){
		if (this.button != null)
			return;
		this.button= GetComponent<Button>();
		Debug.LogWarning("Add Button", gameObject);
	}
}

