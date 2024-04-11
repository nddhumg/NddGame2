using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnhancementCreateManager : NddBehaviour {
	protected EnhancementCode[] arrayEnhancementNameAll = (EnhancementCode[])Enum.GetValues (typeof(EnhancementCode));
	private static EnhancementCreateManager instance;
	[SerializeField] private int valueEnhancementCreate = 3;
	[SerializeField] private UnlockAbilityPlayer unlockAbilityPlayer;

	public static EnhancementCreateManager Instance{
		get{
			return instance;
		}
	}
	protected override void LoadSingleton() {
		if (EnhancementCreateManager.instance != null) {
			Debug.LogError("Only 1 EnhancementCreateManager allow to exist");
		}
		EnhancementCreateManager.instance = this;
	}

	public virtual void CreateCard(){
		EnhancementSelectManager.Instance.SetProperties (CreateEnhancementRandom());
		EnhancementSelectManager.Instance.EnableEnhancementSelect();
	}
	protected virtual EnhancementCode[] CreateEnhancementRandom(){
		EnhancementCode[] arrEnhancementRandom = new EnhancementCode[3];
		List<int> valueRandom = new List<int>();
		for (int countGet = 0; countGet < valueEnhancementCreate; countGet++) {
			int randomValue = RetrieveDistinctValueInList (valueRandom);
			valueRandom.Add (randomValue);
			arrEnhancementRandom [countGet] = arrayEnhancementNameAll [randomValue];
		}
		return arrEnhancementRandom;
	}
	private int RetrieveDistinctValueInList(List<int> listValue){
		int ran = UnityEngine.Random.Range (1, arrayEnhancementNameAll.Length);
		while (listValue.Contains (ran) || isMaxLevelMaxEnhancementAbility(arrayEnhancementNameAll [ran])) {
			ran = UnityEngine.Random.Range (1, arrayEnhancementNameAll.Length);	
		}
		listValue.Add (ran);
		return ran;
	}
	private bool isMaxLevelMaxEnhancementAbility(EnhancementCode enhancementCode){
		UnlockAbilityPlayer.NameAbilityLock nameAbility = unlockAbilityPlayer.SwithFormEnhancementCodetoNameAbilityUnlock (enhancementCode); 
		if(!unlockAbilityPlayer.IsAbilityUnlocked(nameAbility))
		{
			return false;
		}
		Transform abilityTransform = unlockAbilityPlayer.GetTfByKeyListAbilityTf (nameAbility.ToString ());
		LevelAbility levelAbility = abilityTransform?.GetComponentInChildren<LevelAbility> ();
		return levelAbility.LevelCurrent >= levelAbility.LevelMax;
	}
}
