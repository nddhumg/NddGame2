using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjManager : NddBehaviour {
	[SerializeField] 
	private static Transform player;

	public static Transform Player{
		get{
			return player;
		}
	}
	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadPlayer ();
	}
	protected virtual void LoadPlayer(){
		if (GameObjManager.player != null)
			return;
		GameObjManager.player = GameObject.Find ("Player").transform;
		Debug.Log ("Add static Transform Player", gameObject);		
	}
}
