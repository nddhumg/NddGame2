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
		while (listValue.Contains (ran) || IsMaximumLevelEnhancementAbility(arrayEnhancementNameAll [ran])) {
			ran = UnityEngine.Random.Range (1, arrayEnhancementNameAll.Length);	
		}
		return ran;
	}
	private bool IsMaximumLevelEnhancementAbility(EnhancementCode enhancementCode){
		Transform abilityTransform = unlockAbilityPlayer.GetAbilityUnLock (enhancementCode.ToString ());
		if (abilityTransform == null)
			return false;
		LevelAbility levelAbility = abilityTransform?.GetComponentInChildren<LevelAbility> ();
		return levelAbility.LevelCurrent >= levelAbility.LevelMax;
	}
}
