using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class TilemapBaseBox : NddBehaviour {
	protected override void LoadComponent(){
	
	}
	protected virtual void LoadBoxBase(){
		BoxCollider2D box = GetComponent<BoxCollider2D> ();
		box.offset = new Vector2 (1f, -2f);
		box.offset = new Vector2 (64.1f, 36);
		box.isTrigger = true;
	}
}
