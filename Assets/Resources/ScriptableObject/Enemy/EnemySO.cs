using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemy", menuName = "SOCollider/Enemy")]
public class EnemySO : SOColliderCapsule {
	public string enemyName = "Enemy";
	public string classify; 
	public float hpMax = 2;
	public float damage = 1;

}
