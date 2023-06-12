using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyArc", menuName = "SOCollider/Enemy/EnemyArcher")]
public class EnemyArcSO : EnemySO {
	public string nameBulletShot;
	EnemyArcSO(){
		this.classify = "Archer";
	}
}
