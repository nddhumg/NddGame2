using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Exp", menuName = "SOCollider/Exp" +"")]

public class ExpSO : ScriptableObject {
	public ExpName expName = ExpName.NoName;
	public SizeCapsule sizeCapsule;
	public float experience = 0;

}
