using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnhancementType{
	NoType = 0,
	Enhancement = 1,
	Ability =2,
	LevelAbility = 3,
}
public enum EnhancementCode{
	NoName = 0,

	BoostDamage = 1,
	BoostHp =2,
	BoostSpeed =3,
	BoostSpeedAttack =4, 
	BoostRangePickUp =5,


	AbilityCircular = 100,
	AbilityPlayerWaterTornado =101,
	AbilityHolySword = 102
}
public class EnhancementOptions : NddBehaviour {
	private static EnhancementOptions instance;
	public static EnhancementOptions Instance{
		get{
			return instance;
		}
	}
	protected override void LoadSingleton() {
		if (EnhancementOptions.instance != null) {
			Debug.LogError("Only 1 EnhancementOptions allow to exist");

		}
		EnhancementOptions.instance = this;
	}

	//Obsever pattern
	private List<IEvenetEnhancementSelection> obsevers = new List<IEvenetEnhancementSelection>();

	public void AddObsever(IEvenetEnhancementSelection obsever){
		obsevers.Add (obsever);
	}
	public void RemoveObsever(IEvenetEnhancementSelection obsever){
		obsevers.Remove (obsever);
	}
	protected void NotifyObsevers(EnhancementCode dataEnhancementCode){
		foreach (IEvenetEnhancementSelection obsever in obsevers) {
			obsever.OnSelectionEnhancement (dataEnhancementCode);
		}
	}
	public void SelectEnhacement(EnhancementCode selectEnhacementCode){
		NotifyObsevers (selectEnhacementCode);
	}
}
