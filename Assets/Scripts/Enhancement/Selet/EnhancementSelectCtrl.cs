using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnhancementSelectCtrl : NddBehaviour {
	[SerializeField] protected Image imgIcon;
	[SerializeField] protected Text textEnhancementSelect;
	[SerializeField] protected EnhancementSelectProperties enhancementSelectProperties;
	public Image ImgIcon{
		get{
			return imgIcon;
		}
	}
	public Text TextEnhancementSelect{
		get{
			return textEnhancementSelect;
		}
	}
	public EnhancementSelectProperties EnhancementSelectProperties{
		get{
			return enhancementSelectProperties;
		}
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadImgIcon ();
		this.LoadTextEnhancementSelect ();
		this.LoadEnhancementSelectManager ();
	}
	protected virtual void LoadImgIcon(){
		if (this.imgIcon != null)
			return;
		this.imgIcon= transform.Find("Icon").GetComponent<Image>();
		Debug.LogWarning ("Add Image Icone", gameObject);
	}
	protected virtual void LoadTextEnhancementSelect(){
		if (this.textEnhancementSelect != null)
			return;
		this.textEnhancementSelect= GetComponentInChildren<Text>();
		Debug.LogWarning ("Add Text EnhancementSelect", gameObject);
	}
	protected virtual void LoadEnhancementSelectManager(){
		if (this.enhancementSelectProperties != null)
			return;
		this.enhancementSelectProperties= GetComponentInChildren<EnhancementSelectProperties>();
		Debug.LogWarning ("Add EnhancementSelectManager", gameObject);
	}
}

