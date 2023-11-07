using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : GameObjCtrl {
	[SerializeField] protected DestroyItem destroyItem;
	[SerializeField] protected ItemSO itemSO;
	[SerializeField] protected string resPathSO = "ScriptableObject/Item/";
	public DestroyItem DestroyItem{
		get{
			return destroyItem;
		}
	}
	public ItemSO ItemSO{
		get{
			return itemSO;
		}
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadDestroyItem ();
		this.LoadItemSO ();

	}
	protected virtual void LoadDestroyItem(){
		if (this.destroyItem != null)
			return;
		this.destroyItem= GetComponentInChildren<DestroyItem>();
		Debug.LogWarning ("Add DestroyItem", gameObject);
	}
	protected virtual void LoadItemSO(){
		if (this.itemSO  != null)
			return;
		string resPath = resPathSO + transform.name;
		this.itemSO = Resources.Load<ItemSO> (resPath);
		Debug.LogWarning (transform.name + " LoadItemSO " + resPath, gameObject);
	}
}
