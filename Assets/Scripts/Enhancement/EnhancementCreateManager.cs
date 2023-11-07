using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnhancementCreateManager : NddBehaviour {
	protected EnhancementCode[] arrayEnhancementNameAll = (EnhancementCode[])Enum.GetValues (typeof(EnhancementCode));
	private static EnhancementCreateManager instance;
	[SerializeField] private int valueEnhancementCreate = 3;
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
		EnhancementSelectManager.Instance.SetActiveEnhancementSelect (true);
	}
	protected virtual void SendnhancementToSelect(){
		EnhancementSelectManager.Instance.SetProperties (CreateEnhancementRandom());
	}
	protected virtual EnhancementCode[] CreateEnhancementRandom(){
		EnhancementCode[] arrEnhancementRandom = new EnhancementCode[3];
		List<int> indexRandom = new List<int>();
		for (int countGet = 0; countGet < valueEnhancementCreate; countGet++) {
			int ran = UnityEngine.Random.Range (1, arrayEnhancementNameAll.Length);
			while (indexRandom.Contains (ran)) {
				ran = UnityEngine.Random.Range (1, arrayEnhancementNameAll.Length);	
			}
			indexRandom.Add (ran);
			arrEnhancementRandom [countGet] = arrayEnhancementNameAll [ran];
		}
		return arrEnhancementRandom;
	}
}
