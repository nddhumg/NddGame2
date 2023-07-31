using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoolDownIconAbility : NddBehaviour {
	[SerializeField]protected Image coolDown;
	[SerializeField]protected PlayerCtrl playerCtrl;
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadPlayerCtrl ();
		this.LoadCoolDown ();
	}
	protected virtual void LoadPlayerCtrl(){
		if (this.playerCtrl != null)
			return;
		this.playerCtrl= GameObject.Find ("Player").GetComponent<PlayerCtrl>();
		Debug.Log ("Add PlayerCtrl", gameObject);

	}
	protected virtual void LoadCoolDown(){
		if (this.coolDown != null)
			return;
		this.coolDown= transform.Find ("CoolDownDash").GetComponent<Image>();
		Debug.Log ("Add CoolDown", gameObject);
	}
	void FixedUpdate(){
		this.ShowCoolDown ();
	}
	protected void ShowCoolDown(){
		float delay=  playerCtrl.DashPlayer.DelayAbility;
		float timer=  playerCtrl.DashPlayer.TimerAbility;
		coolDown.fillAmount = 1 - (timer / delay);
	}

}
