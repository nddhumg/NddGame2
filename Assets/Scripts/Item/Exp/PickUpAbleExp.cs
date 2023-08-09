using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAbleExp : PickUpAbleItem {
	[SerializeField]protected ExpCtrl expCtrl;
	protected override void LoadItemCtrl(){
		
		base.LoadItemCtrl ();
		expCtrl = itemCtrl as ExpCtrl;
	}

	protected override void	 ActiveItemWhenPickUp ()
	{
		//SoundManager.Instance.OnPlayeSound (SoundType.PickUpItem);
		SpawnSound.Instance.Spawn (SoundType.PickUpItem.ToString(),transform.position,Quaternion.identity);
		LevelPlayer.Instance.IncreaseExp (expCtrl.ExpSO.experience);
	}
}
