using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFx : SpawnsPoolOgj {
	[SerializeField] protected string fxSurf = "FXSurf";

	public string FxSurf{
		get{
			return fxSurf;
		}
	}
	private static SpawnFx instance;
	public static SpawnFx Instance{
		get{
			return instance;
		}
	}

	protected override void LoadSingleton() {
		if (SpawnFx.instance != null) {
			Debug.LogError ("Only 1 SpawnFx allow to exist");
		}
		SpawnFx.instance = this;
	}
}
