using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFx : SpawnsPoolOgj {
	[SerializeField] protected string fxSurf = "FxDash";
	[SerializeField] protected string fxLevelUp = "FxLevelUp";
	public string FxSurf{
		get{
			return fxSurf;
		}
	}
	public string FxLevelUp{
		get{
			return fxLevelUp;
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
