using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarBoss : NddBehaviour {
	[SerializeField]protected BossCtrl bossCtrl;
	[SerializeField] private Image imageHealth;
	[SerializeField] private Text textName;
	[SerializeField] private Text textHealth;
	[SerializeField]protected float valuePercentage;
	[SerializeField]protected float valueCurrent ;
	[SerializeField]protected float valueMax ;

	protected override void Start ()
	{
		base.Start ();
		bossCtrl.DamageReceiverBoss.OnDeadEvent += DestroyBar;
	}
	void OnDestroy(){
		bossCtrl.DamageReceiverBoss.OnDeadEvent -= DestroyBar;
	}
	protected virtual void FixedUpdate(){
		this.GetValue ();
		this.ImageFillNow ();
		TextHealthNow ();
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadTextNameBoss ();
	}
	protected virtual void LoadTextNameBoss(){
		if (this.textName != null)
			return;
		this.textName= transform.Find("NameBoss").GetComponent<Text>();
		Debug.LogWarning ("Add TextNameBoss", gameObject);
	}
	private void GetValue(){
		if (bossCtrl == null)
			return;
		valueCurrent = bossCtrl.DamageReceiverEnemy.Hp;
	}
	private void DestroyBar(){
		Destroy (gameObject);
	}
	protected virtual void ImageFillNow(){
		valuePercentage = valueCurrent / valueMax;
		imageHealth.fillAmount = valuePercentage;
	}
	protected virtual void TextHealthNow(){
		textHealth.text = valueCurrent + "/" + valueMax;
	}
	public void SetEnemyCtrl(BossCtrl ctrl){
		bossCtrl = ctrl;
		valueMax = bossCtrl.DamageReceiverEnemy.HpMax;
		textName.text = bossCtrl.transform.name;
	}
}