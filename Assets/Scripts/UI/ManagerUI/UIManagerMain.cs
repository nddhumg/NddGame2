using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerMain : NddBehaviour {
	[SerializeField] private GameObject uiOption;
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadUIOption ();
	}
	protected virtual void LoadUIOption(){
		if(uiOption !=null){
			return;
		}
		uiOption = transform.Find("Option").gameObject;
		uiOption?.SetActive (false);
		Debug.LogWarning ("Add Option UI", gameObject);
	}
	public void OnClickPlay(){
		LoadScene.Instance.LoadScenePlay ();
	}
	public void OnClickOption(){
		uiOption.SetActive (true);
	}
	public void OnClickExit(){
		Application.Quit ();
	}
}
