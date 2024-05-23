using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class StatInfo{
	public StatsName name;
	public float value;
}
[CreateAssetMenu(fileName = "Stats", menuName = "Stats")]
public class SOStat : ScriptableObject {
	public List<StatInfo> stats = new List<StatInfo>();

	public float GetValueStat(StatsName stat){
		foreach (StatInfo info in stats) {
			if (info.name == stat) {
				return info.value;
			}
		}
		Debug.LogError ("There are no {stat} in the list.");
		return 0;
	}
}
