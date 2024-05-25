using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSelectCtrl : NddBehaviour {
	[SerializeField] protected GameObject backGround;
	[SerializeField] protected Image imgIcon;
	[SerializeField] protected Text textExplainEnhancementSelect;
	[SerializeField] protected Text textLevelEnhancementSelect;
	[SerializeField] protected EnhancementSelectProperties enhancementSelectProperties;
	[SerializeField] protected EnhacementSelectAnimation enhacementSelectAnimation;
	public EnhacementSelectAnimation UpgradeSelectAnimation{
		get{
			return enhacementSelectAnimation;
		}
	}
	public GameObject BackGround{
		get{
			return backGround;
		}
	}
	public Image ImgIcon{
		get{
			return imgIcon;
		}
	}
	public Text TextEnhancementSelect{
		get{
			return textExplainEnhancementSelect;
		}
	}
	public Text TextLevelEnhancementSelect{
		get{
			return textLevelEnhancementSelect;
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
		ActiveTfChild (true);
		this.LoadImgIcon ();
		this.LoadTextExplainEnhancementSelect ();
		this.LoadEnhancementSelectManager ();
		LoadTextLevelEnhancementSelect ();
		LoadBackGround ();
		LoadEnhacementSelectAnimation ();
		ActiveTfChild (false);
	}
	public void ActiveTfChild(bool isActive){
		foreach (Transform tf in transform) {
			tf.gameObject.SetActive (isActive);
		}
	}
	protected virtual void LoadBackGround(){
		if (this.backGround != null)
			return;
		this.backGround= transform.Find("BG").gameObject;
		Debug.LogWarning ("Add BackGround", gameObject);
	}
	protected virtual void LoadImgIcon(){
		if (this.imgIcon != null)
			return;
		this.imgIcon= transform.Find("Icon").GetComponent<Image>();
		Debug.LogWarning ("Add Image Icone", gameObject);
	}
	protected virtual void LoadTextExplainEnhancementSelect(){
		if (this.textExplainEnhancementSelect != null)
			return;
		this.textExplainEnhancementSelect= transform.Find("Explain").GetComponent<Text>();
		Debug.LogWarning ("Add Text Explain EnhancementSelect", gameObject);
	}
	protected virtual void LoadTextLevelEnhancementSelect(){
		if (this.textLevelEnhancementSelect != null)
			return;
		this.textLevelEnhancementSelect= transform.Find("Level").GetComponent<Text>();
		Debug.LogWarning ("Add Text Level EnhancementSelect", gameObject);
	}
	protected virtual void LoadEnhancementSelectManager(){
		if (this.enhancementSelectProperties != null)
			return;
		this.enhancementSelectProperties= GetComponentInChildren<EnhancementSelectProperties>();
		Debug.LogWarning ("Add EnhancementSelectManager", gameObject);
	}
	protected virtual void LoadEnhacementSelectAnimation(){
		if (this.enhacementSelectAnimation != null)
			return;
		this.enhacementSelectAnimation= GetComponent<EnhacementSelectAnimation>();
		Debug.LogWarning ("Add EnhacementSelectAnimation", gameObject);
	}
}

