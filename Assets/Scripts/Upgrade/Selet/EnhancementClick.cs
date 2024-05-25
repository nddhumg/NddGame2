using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhancementClick :  ButtonBase {
	[SerializeField] protected UpgradeSelectCtrl enhancementSelectCtrl;
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
		enhancementSelectCtrl = transform.GetComponent<UpgradeSelectCtrl> ();
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
		UpgradeCode nameEnhancementSelect = enhancementSelectCtrl.EnhancementSelectProperties.NameEnhancementSelect;
		UpgradeManager.Instance.SelectEnhacement (nameEnhancementSelect);
		UpgradeManager.Instance.SelectClick ();
	}	

}
 