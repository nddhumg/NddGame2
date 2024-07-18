using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSelectProperties : NddBehaviour {
	protected UpgradeStatSO upgradeStat;
	protected UpgradeAbilitySO upgradeAbility;
	string resPath;

	[SerializeField]protected UpgradeCode nameEnhancementSelect;
	[SerializeField]protected UpgradeSelectCtrl enhancementSelectCtrl;
	[SerializeField]protected string resPathSO = "ScriptableObject/Upgrade/";

	public UpgradeCode  NameEnhancementSelect{
		get{
			return nameEnhancementSelect;
		}
	}
	public UpgradeStatSO  UpgradeStatSO{
		get{
			return upgradeStat;
		}
	}


	public virtual void LoadInfoUpgradeStat(UpgradeCode nameData){
		upgradeAbility = null;
		resPath = resPathSO + nameData.ToString();
		upgradeStat = Resources.Load<UpgradeStatSO> (resPath);
		if(upgradeStat == null)
		{
			Debug.LogError("Error LoadInfo Stat,"+ nameData.ToString() + ", " + resPath);
			return;
		}
		LoadUpgradeUI(nameData,upgradeStat.image, upgradeStat.explain, "");
		
	}
	public virtual void LoadInfoUpgradeAbility(UpgradeCode nameData,int level){
		upgradeAbility = null;
		resPath = resPathSO + nameData.ToString();
		upgradeAbility = Resources.Load<UpgradeAbilitySO> (resPath);
		if(upgradeAbility == null)
		{
			Debug.LogError("Error LoadInfo Ability, "+ nameData.ToString() + ", " + resPath );
			return;
		}
		LoadUpgradeUI (nameData,upgradeAbility.image, upgradeAbility.listExplain [level], "Level: " + (level + 1));
	}


	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadEnhancementSelectCtrl ();
	}

	protected virtual void LoadEnhancementSelectCtrl(){
		if (this.enhancementSelectCtrl != null)
			return;
		this.enhancementSelectCtrl= transform.parent.GetComponent<UpgradeSelectCtrl>();
		Debug.LogWarning ("Add EnhancementSelectCtrl", gameObject);
	}
	protected virtual void LoadUpgradeUI(UpgradeCode codeName,Sprite sprite, string textExplain, string textLevel){
		nameEnhancementSelect = codeName;
		enhancementSelectCtrl.ImgIcon.sprite = sprite;
		enhancementSelectCtrl.TextUpgradeExplain.text = textExplain;
		enhancementSelectCtrl.TextLevelUpgrade.text = textLevel;
	}
}
