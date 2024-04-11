using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhancementClick :  ButtonBase {
	[SerializeField] protected EnhancementSelectCtrl enhancementSelectCtrl;
	void OnEnable(){
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadEnhancementSelectCtrl ();
	}

	protected virtual void LoadEnhancementSelectCtrl(){
		if (enhancementSelectCtrl != null)
			return;
		enhancementSelectCtrl = transform.GetComponent<EnhancementSelectCtrl> ();
		Debug.LogWarning ("Add EnhancementSelectCtrl", gameObject);
	}

	protected override void OnClick ()
	{
		SendNameEnhancementSelect ();
	}
	public void SendNameEnhancementSelect(){
		if (transform.rotation.eulerAngles != Vector3.zero)
			return;
		if (UIManagerPlay.Instance.IsOpenUISetting)
			return;
		EnhancementCode nameEnhancementSelect = enhancementSelectCtrl.EnhancementSelectProperties.NameEnhancementSelect;
		EnhancementOptions.Instance.SelectEnhacement (nameEnhancementSelect);
		EnhancementSelectManager.Instance.SelectClick ();
	}	

}
 