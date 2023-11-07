using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffItemCtrl : ItemCtrl {
	[SerializeField]protected BuffItemSO buffItemSO;
	protected override void ResetValue ()
	{
		base.ResetValue ();
		resPathSO  = "ScriptableObject/Item/BuffItem/";
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		ConvertBuffItemSO ();
	}
	protected virtual void ConvertBuffItemSO(){
		if (this.buffItemSO != null)
			return;
		
		buffItemSO = itemSO as BuffItemSO;
		Debug.LogWarning ("ItemSO convert to BuffItemSO", gameObject);
	}
}
