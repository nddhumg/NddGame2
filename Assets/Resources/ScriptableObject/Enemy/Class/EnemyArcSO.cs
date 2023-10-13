using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyArc", menuName = "SOCollider/Enemy/EnemyArcher")]
public class EnemyArcSO : EnemySO {
	[Header("Arc")]
	public BulletName nameBulletShot;
	EnemyArcSO(){
		this.classify = ClassifyEnemy.Archer;
	}
}
