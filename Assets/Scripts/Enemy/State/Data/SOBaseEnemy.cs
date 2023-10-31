using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newBaseEnemyState", menuName = "SO/State/BaseEnemy" +"")]
public class SOBaseEnemy : ScriptableObject {
	public float attackRange = 3;
	public float distanceStopMove = 2;
}
