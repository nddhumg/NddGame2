using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhancementSelectProperties : NddBehaviour {
	protected UpgradeCardSO enhancementCard;
	protected CardAbilitySO abilityCard;
	string resPath;
	[SerializeField]protected UpgradeCode nameEnhancementSelect;
	[SerializeField]protected UpgradeSelectCtrl enhancementSelectCtrl;

	public UpgradeCode  NameEnhancementSelect{
		get{
			return nameEnhancementSelect;
		}
	}
	public virtual void LoadInfoUpgradeNormal(UpgradeCode nameData){
		try{
			resPath = "ScriptableObject/Enhancement/" +	nameData.ToString();;
			enhancementCard = Resources.Load<UpgradeCardSO> (resPath);
			nameEnhancementSelect = enhancementCard.nameCard;
			enhancementSelectCtrl.ImgIcon.sprite = enhancementCard.image;
			enhancementSelectCtrl.TextLevelEnhancementSelect.text= "";
			enhancementSelectCtrl.TextEnhancementSelect.text = enhancementCard.explain ;
		}
		catch{
			Debug.LogError ("Error LoadInfo Select: " + nameData.ToString() , gameObject);
		}
	}
	public virtual void LoadInfoUpgradeAbility(UpgradeCode nameData,int level){
		string resPath = "ScriptableObject/Enhancement/" +	nameData.ToString();
		abilityCard = Resources.Load<CardAbilitySO> (resPath);
		if(abilityCard == null)
		{
			Debug.LogError("Error LoadInfo Ability, SO null",gameObject);
			return;
		}
		nameEnhancementSelect = abilityCard.nameCard;
		enhancementSelectCtrl.ImgIcon.sprite = abilityCard.image;
		enhancementSelectCtrl.TextEnhancementSelect.text = abilityCard.listExplain[level];
		enhancementSelectCtrl.TextLevelEnhancementSelect.text = "Level: "+(level+1);

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
}
