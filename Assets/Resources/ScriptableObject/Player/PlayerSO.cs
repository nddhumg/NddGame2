using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Player", menuName = "SOCollider/Player")]
public class PlayerSO : ScriptableObject {
	public string namePlayer = "Player";
	public SizeCapsule sizeCapsule;
	public float hpMax = 1000;
	public float damage = 100;
	public string[] nameBullets;
}
