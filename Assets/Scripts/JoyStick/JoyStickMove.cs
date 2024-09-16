using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickMove : JoyStick {
	private static JoyStickMove instance;
	public static JoyStickMove Instance{
		get{
			return instance;
		}
	}

	protected override void LoadSingleton() {
		if (JoyStickMove.instance != null) {
			Debug.LogError("Only 1 JoyStickMove allow to exist");

		}
		JoyStickMove.instance = this;
	}
}
