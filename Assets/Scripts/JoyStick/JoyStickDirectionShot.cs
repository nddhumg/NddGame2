using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickDirectionShot : JoyStick {
	private static JoyStickDirectionShot instance;
	public static JoyStickDirectionShot Instance{
		get{
			return instance;
		}
	}

	protected override void LoadSingleton() {
		if (JoyStickDirectionShot.instance != null) {
			Debug.LogError("Only 1 JoyStickDirectionShot allow to exist");

		}
		JoyStickDirectionShot.instance = this;
	}

	protected override void EndControl ()
	{
		isControl = false;
	}
}
