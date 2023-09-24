using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "SOCollider/Item" +"")]

public class ItemSO : ScriptableObject {
	public ItemName itemName = ItemName.NoName;
	public SizeCapsule sizeCapsule;
}

