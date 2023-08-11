using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : NddBehaviour {
	[SerializeField]protected Slider slider;
	[SerializeField]protected PlayerCtrl playerCtrl;
	[SerializeField]protected Text textHp;
	[SerializeField]protected float percentageHp;
	[SerializeField]protected float hpCurrent ;
	[SerializeField]protected float hpMax ;
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadPlayerCtrl ();
		this.LoadSlider ();
		this.LoadText ();
	}
	protected virtual void LoadPlayerCtrl(){
		
		if (this.playerCtrl != null)
				return;
		this.playerCtrl= GameObject.Find ("Player").GetComponent<PlayerCtrl>();
		Debug.LogWarning ("Add PlayerCtrl", gameObject);
	}
	protected virtual void LoadSlider(){
		if (this.slider != null)
			return;
		this.slider= GetComponent<Slider>();
		Debug.LogWarning ("Add Slider", gameObject);

	}
	protected virtual void LoadText(){
		if (this.textHp != null)
			return;
		this.textHp= GetComponentInChildren<Text>();
		Debug.LogWarning ("Add Text", gameObject);

	}
	void FixedUpdate(){
		this.GetHpPlayer ();
		this.HealthCurrunt ();
		this.TextHpPlayer ();
	}
	protected void GetHpPlayer(){
		 hpCurrent = playerCtrl.DamageReceiver.Hp;
		 hpMax = playerCtrl.DamageReceiver.HpMax;
	}
	protected void HealthCurrunt(){
		percentageHp = hpCurrent / hpMax;
		slider.value = percentageHp;
	}
	protected void TextHpPlayer(){
		string textPercentageHp = hpCurrent.ToString() +"/"+ hpMax.ToString ();
		this.textHp.text = textPercentageHp;
	}
}
