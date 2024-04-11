using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnhancementSelectManager : NddBehaviour {
	[SerializeField] protected List<EnhancementSelectCtrl> listEnhancementSelectCtrl;
	[SerializeField] protected Transform enhancementSelect;
	[SerializeField] protected UnlockAbilityPlayer unlockAbilityPlayer;

	private static EnhancementSelectManager instance;
	public static EnhancementSelectManager Instance{
		get{
			return instance;
		}
	}
	protected override void LoadSingleton() {
		if (EnhancementSelectManager.instance != null) {
			Debug.LogError("Only 1 EnhancementSelectManager allow to exist");

		}
		EnhancementSelectManager.instance = this;
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
			EnhancementSelectCtrl ctrl = tf.GetComponent<EnhancementSelectCtrl>();
			if (ctrl == null)
				continue;
			listEnhancementSelectCtrl.Add (ctrl);
		}
		Debug.LogWarning ("Add List Ctrl Enhancement Select");
	}
	public virtual void SetProperties(EnhancementCode[] arrEnhancementCode){
		int i = 0;
		foreach (EnhancementSelectCtrl ctrl in listEnhancementSelectCtrl) {
			var properties = ctrl.EnhancementSelectProperties;
			EnhancementCode enhancementCode = arrEnhancementCode [i];
			if (IsEnhancementAbility(enhancementCode)) {
				properties.LoadInfoEnhancementSelect (enhancementCode,GetLevelEnhancementAbility(enhancementCode));
			} else {
				properties.LoadInfoEnhancementSelect (enhancementCode);
			}
			i++;
		}	
	}
	private bool IsEnhancementAbility(EnhancementCode enhancementCode){
		return (int)enhancementCode >= 100;
	}
	private int GetLevelEnhancementAbility(EnhancementCode enhancementCode){
		UnlockAbilityPlayer.NameAbilityLock nameAbility = unlockAbilityPlayer.SwithFormEnhancementCodetoNameAbilityUnlock (enhancementCode); 	
		if(!unlockAbilityPlayer.IsAbilityUnlocked(nameAbility))
		{
			return 0;
		}
		Transform abilityTransform = unlockAbilityPlayer.GetTfByKeyListAbilityTf (nameAbility.ToString ());
		LevelAbility levelAbility = abilityTransform?.GetComponentInChildren<LevelAbility> ();
		return (int)levelAbility.LevelCurrent;
	}
	public virtual void EnableEnhancementSelect(){
		enhancementSelect.gameObject.SetActive (true);
		MainPlay.Instance.PauseGame ();
	}

	public virtual void DisableEnhancementSelect(){
		enhancementSelect.gameObject.SetActive (false);
		MainPlay.Instance.ResumeGame ();
	}

	public virtual void SelectClick(){
		foreach (EnhancementSelectCtrl ctrl in listEnhancementSelectCtrl) {
			ctrl.EnhacementSelectAnimation.StartAnimationDisable ();
		}
	}
}
