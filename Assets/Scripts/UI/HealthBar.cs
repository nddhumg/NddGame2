using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : NddBehaviour {
	[SerializeField]protected Slider slider;
	[SerializeField]protected PlayerCtrl playerCtrl;
	[SerializeField]protected float percentageHp;
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadPlayerCtrl ();
		this.LoadSlider ();
	}
	protected virtual void LoadPlayerCtrl(){
		
		if (this.playerCtrl != null)
				return;
		this.playerCtrl= GameObject.Find ("Player").GetComponent<PlayerCtrl>();
		Debug.Log ("Add PlayerCtrl", gameObject);

	}

	protected virtual void LoadSlider(){

		if (this.slider != null)
			return;
		this.slider= GetComponent<Slider>();
		Debug.Log ("Add Slider", gameObject);

	}

	void FixedUpdate(){
		this.HealthCurrunt ();
	}
	protected void HealthCurrunt(){
		float hpCurrent = playerCtrl.DamageReceiver.Hp;
		float hpMax = playerCtrl.DamageReceiver.HpMax;
		percentageHp = hpCurrent / hpMax;
		slider.value = percentageHp;
	}
}
