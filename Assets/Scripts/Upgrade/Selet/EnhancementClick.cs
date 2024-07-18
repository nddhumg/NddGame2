using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhancementClick :  ButtonBase {
	[SerializeField] protected UpgradeSelectCtrl upgradeSelectCtrl;
	void OnEnable(){
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadEnhancementSelectCtrl ();
	}

	protected virtual void LoadEnhancementSelectCtrl(){
		if (upgradeSelectCtrl != null)
			return;
		upgradeSelectCtrl = transform.GetComponent<UpgradeSelectCtrl> ();
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
		UpgradeCode nameEnhancementSelect = upgradeSelectCtrl.EnhancementSelectProperties.NameEnhancementSelect;
		if (UpgradeManager.Instance.IsUpgradeAbility (nameEnhancementSelect)) {
			UpgradeManager.Instance.OnUpgradeAbility (nameEnhancementSelect);
		}
		else 
			UpgradeManager.Instance.OnUpgradeStat(upgradeSelectCtrl.EnhancementSelectProperties.UpgradeStatSO);
		
		UpgradeManager.Instance.SelectClick ();
	}	

}
 