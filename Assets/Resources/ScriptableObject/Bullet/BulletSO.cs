using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Bullet", menuName = "SOCollider/Bullet")]
public class BulletSO : SOColliderCapsule {
	public string bulletName = "Bullet";
	public float damage = 1;
	public float speed = 10f;
	public string tagShooter;
}
