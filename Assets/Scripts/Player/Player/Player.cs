using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NddBehaviour {
	private static Player instance;
	public static Player Instance{
		get{ 
			return instance;
		}
	}
	protected override void LoadSingleton() {
		if (Player.instance != null) {
			Debug.LogError("Only 1 Player allow to exist");
		}
		Player.instance = this;
	}
	public Vector3 GetPosition(){
		return transform.position;
	}

}
