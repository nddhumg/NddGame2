using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Exp", menuName = "SOCollider/Exp" +"")]

public class ExpSO : SOColliderCapsule {
	public ExpName expName = ExpName.NoName;
	public float experience = 0;
}
