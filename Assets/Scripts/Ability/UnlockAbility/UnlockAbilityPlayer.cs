using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnlockAbilityPlayer : NddBehaviour {
	[System.Serializable]
	public class MyDictionaryTransform
	{
		public string key;
		public Transform value;
		public MyDictionaryTransform(string key,Transform value){
			this.key = key;
			this.value = value;
		}
	}

	[SerializeField]protected List<MyDictionaryTransform> listAbilityTf = new List<MyDictionaryTransform>();
	[SerializeField]private List<NameAbilityLock> listAbilityUnlock = new List<NameAbilityLock>();

	public  List<MyDictionaryTransform> ListAbilityTf{
		get{
			return listAbilityTf;
		}
	}
	public enum NameAbilityLock
	{
		NoAbility =0,
		AbilityCircular =1,
		AbilityPlayerWaterTornado = 2,
	}

	public Transform GetTfByKeyListAbilityTf(string key){
		foreach (MyDictionaryTransform myDictionary in listAbilityTf) {
			if (myDictionary.key == key)
				return myDictionary.value;
		}
		return null;
	}
	public NameAbilityLock SwithFormEnhancementCodetoNameAbilityUnlock(EnhancementCode enhancementCode){
		string enhancementCodeString = enhancementCode.ToString();
		foreach (UnlockAbilityPlayer.NameAbilityLock name in Enum.GetValues(typeof(UnlockAbilityPlayer.NameAbilityLock))) {
			if (name.ToString () == enhancementCodeString)
				return name;
		}
		return UnlockAbilityPlayer.NameAbilityLock.NoAbility;

//		UnlockAbilityPlayer.NameAbilityLock result;
//
//		if (Enum.TryParse(enhancementCodeString, out result))
//		{
//			return (UnlockAbilityPlayer.NameAbilityLock)result;
//		}
//		else
//		{
//			return UnlockAbilityPlayer.NameAbilityLock.NoAbility;
//		}
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadListAbility ();
	}

	protected virtual void LoadListAbility(){
		if (listAbilityTf.Count != 0)
			return;
		foreach (Transform obj in transform) {
			listAbilityTf.Add (new MyDictionaryTransform(obj.name, obj));
			obj.gameObject.SetActive (false);
		}
		Debug.Log ("Add dictionaryAbilityTf", gameObject);
	}
	public void UnlockAbility(NameAbilityLock nameAbility){
		if (IsAbilityUnlocked (nameAbility))
			return;
		listAbilityUnlock.Add (nameAbility);
		GetTfByKeyListAbilityTf(nameAbility.ToString()).gameObject.SetActive (true);
	}

	public bool IsAbilityUnlocked(NameAbilityLock nameAbility){
		return listAbilityUnlock.Contains(nameAbility);
	}
	public bool IsPlayerAbilityLock(string nameAbility){
		return Enum.IsDefined (typeof(NameAbilityLock), nameAbility);
	}
}
