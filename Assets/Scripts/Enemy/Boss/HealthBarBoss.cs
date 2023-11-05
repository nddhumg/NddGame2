using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarBoss : NddBehaviour {
	[SerializeField]protected EnemyCtrl enemyCtrl;
	[SerializeField] private Image imageHealth;
	[SerializeField] private Text textName;
	[SerializeField] private Text textHealth;
	[SerializeField]protected float valuePercentage;
	[SerializeField]protected float valueCurrent ;
	[SerializeField]protected float valueMax ;

	protected override void Start ()
	{
		base.Start ();
		enemyCtrl.DamageReceiverEnemy.OnDeadEvent += DestroyBar;
	}
	void OnDestroy(){
		enemyCtrl.DamageReceiverEnemy.OnDeadEvent -= DestroyBar;
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
		if (enemyCtrl == null)
			return;
		valueCurrent = enemyCtrl.DamageReceiverEnemy.Hp;
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
	public void SetEnemyCtrl(EnemyCtrl ctrl){
		enemyCtrl = ctrl;
		valueMax = enemyCtrl.DamageReceiverEnemy.HpMax;
		textName.text = enemyCtrl.transform.name;
	}
}