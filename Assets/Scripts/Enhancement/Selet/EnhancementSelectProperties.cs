using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhancementSelectProperties : BaseEnhancementSelect {
	[SerializeField]protected  EnhancementCardSO enhancementCard;
	[SerializeField]protected EnhancementCode nameEnhancementSelect;
	public EnhancementCode  NameEnhancementSelect{
		get{
			return nameEnhancementSelect;
		}
	}
	public virtual void LoadInfoEnhancementSelect(EnhancementCode nameData){
		try{
			string resPath = "ScriptableObject/Enhancement/" +	nameData.ToString();;
			enhancementCard = Resources.Load<EnhancementCardSO> (resPath);
			nameEnhancementSelect = enhancementCard.nameCard;
			enhancementSelectCtrl.ImgIcon.sprite = enhancementCard.image;
			enhancementSelectCtrl.TextLevelEnhancementSelect.text= "";
			enhancementSelectCtrl.TextEnhancementSelect.text = enhancementCard.explain + " +"+enhancementCard.attribute;
		}
		catch{
			Debug.LogError ("Error LoadInfo Select", gameObject);
		}
	}
	public virtual void LoadInfoEnhancementSelect(EnhancementCode nameData,int level){
		try{
			string resPath = "ScriptableObject/Enhancement/" +	nameData.ToString();
			enhancementCard = Resources.Load<EnhancementCardSO> (resPath);
			string resPath2 = "ScriptableObject/Enhancement/Ability/" +	nameData.ToString() +"/Level"+(level+1);
			CardAbilitySO abilityCard = Resources.Load<CardAbilitySO> (resPath2);
			if(abilityCard == null)
			{
				Debug.LogError("Error LoadInfo Ability, SO null",gameObject);
				return;
			}
			nameEnhancementSelect = enhancementCard.nameCard;
			enhancementSelectCtrl.ImgIcon.sprite = enhancementCard.image;
			enhancementSelectCtrl.TextEnhancementSelect.text = abilityCard.explain;
			enhancementSelectCtrl.TextLevelEnhancementSelect.text = "Level: "+abilityCard.level;
		}
		catch{
			Debug.LogError ("Error LoadInfo Ability Select", gameObject);
		}
	}
}
