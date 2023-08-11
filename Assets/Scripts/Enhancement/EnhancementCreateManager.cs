using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnhancementCreateManager : NddBehaviour {
	protected EnhancementCode[] arrayEnhancementNameAll = (EnhancementCode[])Enum.GetValues (typeof(EnhancementCode));
	private static EnhancementCreateManager instance;
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
		EnhancementSelectManager.Instance.SetProperties (GetEnhancementRandom());
		EnhancementSelectManager.Instance.SetActiveEnhancementSelect (true);
	}
	protected virtual void CreateEnhancementRandom(){
		EnhancementSelectManager.Instance.SetProperties (GetEnhancementRandom());
	}
	protected virtual EnhancementCode[] GetEnhancementRandom(){
		EnhancementCode[] arrEnhancementRandom = new EnhancementCode[3];
		for (int countGet = 0; countGet < 3; countGet++) {
			int ran = UnityEngine.Random.Range (1, arrayEnhancementNameAll.Length);
			arrEnhancementRandom [countGet] = arrayEnhancementNameAll [ran];
		}
		return arrEnhancementRandom;
	}
}
