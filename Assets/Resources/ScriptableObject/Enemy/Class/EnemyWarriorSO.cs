using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyWarrior", menuName = "SOCollider/Enemy/EnemyWarrior")]
public class EnemyWarriorSO : EnemySO {
	[Header("Warrior")]
	public Vector2 offsetZoneAttack ;
	EnemyWarriorSO(){
		this.classify = ClassifyEnemy.Warrior;
	}
}
