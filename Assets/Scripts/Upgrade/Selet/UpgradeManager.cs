using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class UpgradeManager : NddBehaviour {
	[SerializeField] protected List<UpgradeSelectCtrl> listEnhancementSelectCtrl;
	[SerializeField] protected Transform enhancementSelect;
	protected UpgradeCode[] arrayEnhancementNameAll = (UpgradeCode[])Enum.GetValues (typeof(UpgradeCode));
	private List<IEvenetUpgradeSelect> obsevers = new List<IEvenetUpgradeSelect>();

	private static UpgradeManager instance;
	public static UpgradeManager Instance{
		get{
			return instance;
		}
	}

	public virtual void CreateUpgradeCard(){
		List<UpgradeCode> upGrades = arrayEnhancementNameAll.ToList();
		foreach (UpgradeSelectCtrl selectCtrl in listEnhancementSelectCtrl) {
			int ran = UnityEngine.Random.Range(1, upGrades.Count);
			UpgradeCode upGreade = upGrades [ran];
			int level = -1;
			while (IsUpgradeAbility (upGreade) && level == -1) {
				upGrades.Remove (upGreade);
				ran = UnityEngine.Random.Range(1, upGrades.Count);
				upGreade = upGrades [ran];
				level = GetLevelEnhancementAbility (upGreade);
			}
			if (IsUpgradeAbility(upGreade)) {
				level = GetLevelEnhancementAbility (upGreade);
				selectCtrl.EnhancementSelectProperties.LoadInfoUpgradeAbility (upGreade,level);
			} else {
				selectCtrl.EnhancementSelectProperties.LoadInfoUpgradeNormal (upGreade);
			}
			upGrades.Remove (upGreade);
		}
		EnableUpgradeSelect ();
	}

	public virtual void EnableUpgradeSelect(){
		enhancementSelect.gameObject.SetActive (true);
		MainPlay.Instance.PauseGame ();
	}

	public virtual void DisableUpgradeSelect(){
		enhancementSelect.gameObject.SetActive (false);
		MainPlay.Instance.ResumeGame ();
	}

	public virtual void SelectClick(){
		foreach (UpgradeSelectCtrl ctrl in listEnhancementSelectCtrl) {
			ctrl.UpgradeSelectAnimation.StartAnimationDisable ();
		}
	}


	protected override void LoadSingleton() {
		if (UpgradeManager.instance != null) {
			Debug.LogError("Only 1 EnhancementSelectManager allow to exist");
		}
		UpgradeManager.instance = this;
	}

	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadEnhancementSelect ();
		this.LoadListEnhancementSelectCtrl ();
	}

	protected virtual void LoadEnhancementSelect(){
		if (this.enhancementSelect)
			return;
		this.enhancementSelect = transform.Find ("EnhancementSelect");
		enhancementSelect.gameObject.SetActive (false);
		Debug.LogWarning ("Add EnhancementSelect");
	}

	protected virtual void LoadListEnhancementSelectCtrl(){
		if (listEnhancementSelectCtrl.Count > 0)
			return;
		if (enhancementSelect == null)
			this.LoadEnhancementSelect ();
		foreach (Transform tf in enhancementSelect) {
			UpgradeSelectCtrl ctrl = tf.GetComponent<UpgradeSelectCtrl>();
			if (ctrl == null)
				continue;
			listEnhancementSelectCtrl.Add (ctrl);
		}
		Debug.LogWarning ("Add List Ctrl Enhancement Select");
	}
	private bool IsUpgradeAbility(UpgradeCode enhancementCode){
		return (int)enhancementCode >= 100;
	}
	private int GetLevelEnhancementAbility(UpgradeCode enhancementCode){
		Transform abilityTransform = PlayerCtrl.Instance.AbilityCtrl.AbilityUnlock.GetAbilityUnLock (enhancementCode.ToString ());
		if(abilityTransform == null)
		{
			return 0;
		}
		LevelAbility levelAbility = abilityTransform?.GetComponentInChildren<LevelAbility> ();
		if (levelAbility.IsLevelMax ())
			return -1;
		return (int)levelAbility.LevelCurrent;
	}
	public void AddObsever(IEvenetUpgradeSelect obsever){
		obsevers.Add (obsever);
	}
	public void RemoveObsever(IEvenetUpgradeSelect obsever){
		obsevers.Remove (obsever);
	}
	protected void NotifyObsevers(UpgradeCode dataEnhancementCode){
		foreach (IEvenetUpgradeSelect obsever in obsevers) {
			obsever.OnSelectionEnhancement (dataEnhancementCode);
		}
	}
	public void SelectEnhacement(UpgradeCode selectEnhacementCode){
		NotifyObsevers (selectEnhacementCode);
	}
}
