using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnlockAbilityPlayer : NddBehaviour {
	[SerializeField] protected List<Transform> listAbilityLock = new List<Transform>();
	[SerializeField] protected List<Transform> listAbilityUnLock = new List<Transform>();


	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadListAbilityLock();
	}
	protected virtual void LoadListAbilityLock(){
		if (listAbilityLock.Count > 0)
			return;
		foreach (Transform ability in transform) {
			listAbilityLock.Add (ability);
			ability.gameObject.SetActive (false);
		}
		Debug.LogWarning ("Add ListAbilityLock", gameObject);
	}

	public Transform UnlockAbility(string nameAbility){
		foreach (Transform ability in listAbilityLock) {
			if (ability.name == nameAbility) {
				ability.gameObject.SetActive (true);
				listAbilityLock.Remove (ability);
				listAbilityUnLock.Add (ability);
				return ability;
			}
		}
		return null;
	}
	public Transform GetAbilityUnLock(string nameAbility){
		foreach (Transform ability in listAbilityUnLock) {
			if (ability.name == nameAbility) {
				return ability;
			}
		}
		return null;
	}

}
