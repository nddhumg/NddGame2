using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BarUI : NddBehaviour {
	[SerializeField]protected Slider slider;
	[SerializeField]protected float valuePercentage;
	[SerializeField]protected float valueCurrent ;
	[SerializeField]protected float valueMax ;
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadSlider ();
	}
	protected virtual void FixedUpdate(){
		this.GetValue ();
		this.SliderUpdate ();
	}
	protected virtual void LoadSlider(){
		if (this.slider != null)
			return;
		this.slider= GetComponent<Slider>();
		Debug.LogWarning ("Add Slider", gameObject);
	}
	protected abstract void GetValue();
	protected virtual void SliderUpdate(){
		valuePercentage = valueCurrent / valueMax;
		slider.value = valuePercentage;
	}
}
