using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarPlayer : BarUI {
	[SerializeField]protected PlayerCtrl playerCtrl;
	[SerializeField]protected Text textHp;

	protected override void Start(){
		base.Start ();
		playerCtrl.DamageReceiver.OnReceiverEvent += UpdateBarHpPlayerUI;
		UpdateBarHpPlayerUI ();
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadPlayerCtrl ();
		this.LoadText ();
	}
	protected virtual void LoadPlayerCtrl(){
		if (this.playerCtrl != null)
				return;
		this.playerCtrl= GameObject.Find ("Player").GetComponent<PlayerCtrl>();
		Debug.LogWarning ("Add PlayerCtrl", gameObject);
	}
	protected virtual void LoadText(){
		if (this.textHp != null)
			return;
		this.textHp= GetComponentInChildren<Text>();
		Debug.LogWarning ("Add Text", gameObject);
	}
	protected virtual void UpdateBarHpPlayerUI(){
		GetValue ();
		ImageFillUpdate ();
		UpdateTextHpPlayer ();
	}

	protected override void GetValue(){
		valueCurrent = playerCtrl.DamageReceiver.Hp;
		valueMax = playerCtrl.DamageReceiver.HpMax;
	}
	protected void UpdateTextHpPlayer(){
		string textPercentageHp = valueCurrent.ToString() +"/"+ valueMax.ToString ();
		this.textHp.text = textPercentageHp;
	}
}
