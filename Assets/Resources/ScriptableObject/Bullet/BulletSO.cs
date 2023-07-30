using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Bullet", menuName = "SOCollider/Bullet")]
public class BulletSO : ScriptableObject {
	public BulletName bulletName = BulletName.NoName;
	public SizeCapsule sizeCapsule;
	public float damage = 1;
	public float speed = 10f;
	public string tagShooter;
}
