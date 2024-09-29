using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSkillSpawner : SpawnPool {
	public enum ObjSkillName{
		NoName = 0,
		WaterTornado = 1
	}
	private static ObjSkillSpawner instance;
	public static ObjSkillSpawner Instance{
		get{
			return instance;
		}
	}

	protected override void LoadSingleton() {
		if (ObjSkillSpawner.instance != null) {
			Debug.LogError ("Only 1 ObjSkillSpawner allow to exist");
		}
		ObjSkillSpawner.instance = this;
	}
}
