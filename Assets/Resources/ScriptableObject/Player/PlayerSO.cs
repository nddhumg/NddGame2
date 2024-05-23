using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Player", menuName = "SOCollider/Player")]
public class PlayerSO : ScriptableObject {
	public string namePlayer = "Player";
	public SizeCapsule sizeCapsule;
	public string[] nameBullets;
}
