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
	public  List<MyDictionaryTransform> ListAbilityTf{
		get{
			return listAbilityTf;
		}
	}
	[SerializeField]private List<NameAbilityUnlock> listAbilityUnlock = new List<NameAbilityUnlock>();

	public enum NameAbilityUnlock
	{
		AbilityCircular =1,
	}

	public Transform GetTfByKeyListAbilityTf(string key){
		foreach (MyDictionaryTransform myDictionary in listAbilityTf) {
			if (myDictionary.key == key)
				return myDictionary.value;
		}
		return null;
	}
	public NameAbilityUnlock SwithFormEnhancementCodetoNameAbilityUnlock(EnhancementCode enhancementCode){
		return  (UnlockAbilityPlayer.NameAbilityUnlock)Enum.Parse(typeof(UnlockAbilityPlayer.NameAbilityUnlock), enhancementCode.ToString());
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
	public void UnlockAbility(NameAbilityUnlock nameAbility){
		if (IsAbilityUnlocked (nameAbility))
			return;
		listAbilityUnlock.Add (nameAbility);
		GetTfByKeyListAbilityTf(nameAbility.ToString()).gameObject.SetActive (true);
	}

	public bool IsAbilityUnlocked(NameAbilityUnlock nameAbility){
		return listAbilityUnlock.Contains(nameAbility);
	}
}
