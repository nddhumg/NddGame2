using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IDropItem
{
	string GetName();
	float GetPercentage();
}
[System.Serializable]
public class DropExpRate : IDropItem {
	public ExpName expName = ExpName.NoName;
	public float percentage = 0;
	public string GetName(){
		return expName.ToString ();
	}
	public float GetPercentage(){
		return percentage;
	}
}

[System.Serializable]
public class DropItemRate : IDropItem  {
	public ItemName itemName = ItemName.NoName;
	public float percentage = 0;
	public string GetName(){
		return itemName.ToString ();
	}
	public float GetPercentage(){
		return percentage;
	}
}
[CreateAssetMenu(fileName = "Enemy", menuName = "SOCollider/Enemy")]
public class EnemySO : ScriptableObject {
	public EnemyName enemyName = EnemyName.NoName;
	public SizeCapsule sizeCapsule;
	public float attackRange ;
	public ClassifyEnemy classify; 
	public float hpMax = 100;
	public float damage = 10;
	public List<DropExpRate> listDropExp;
	public List<DropItemRate> ListDropItem;
}
