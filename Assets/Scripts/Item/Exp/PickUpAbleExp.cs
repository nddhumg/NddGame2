using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAbleExp : PickUpAble {
	[SerializeField]protected ExpCtrl expCtrl;
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadExpCtrl ();

	}
	protected virtual void LoadExpCtrl(){
		if (this.expCtrl != null)
			return;
		this.expCtrl= transform.parent.GetComponent<ExpCtrl>();
		Debug.LogWarning ("Add ExpCtrl", gameObject);
	}

	public override void PickUp(PlayerCtrl playerCtrl){	
		expCtrl.DestroyExp.DestroyObject ();
		base.PickUp (playerCtrl);
	}
	protected override void	 ActiveItemWhenPickUp(PlayerCtrl playerCtrl)
	{
		SoundManager.Instance.OnPlaySound (SoundType.PickUpItem);
		playerCtrl.LevelPlayer.IncreaseExp (expCtrl.ExpSO.experience);
	}
}
