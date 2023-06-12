using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Player", menuName = "SOCollider/Player")]
public class PlayerSO : SOColliderCapsule {
	public string namePlayer = "Player";
	public float hpMax = 100;
	public float speed = 10f;
	public string[] nameBullets;
}
