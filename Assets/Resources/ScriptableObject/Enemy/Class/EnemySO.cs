using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemy", menuName = "SOCollider/Enemy")]
public class EnemySO : ScriptableObject {
	public EnemyName enemyName = EnemyName.NoName;
	public SizeCapsule sizeCapsule;
	public float attackRange ;
	public ClassifyEnemy classify; 
	public float hpMax = 100;
	public float damage = 10;
	public List<DropExpRate> listDropExp;
}
