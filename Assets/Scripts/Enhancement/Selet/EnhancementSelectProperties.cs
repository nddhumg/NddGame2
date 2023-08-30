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
			enhancementSelectCtrl.TextEnhancementSelect.text = enhancementCard.explain + " +"+enhancementCard.attribute;
		}
		catch{
			Debug.LogError ("Error LoadInfo Select", gameObject);
		}
	}
}
