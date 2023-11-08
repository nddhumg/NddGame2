using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderSound : SliderBase {
	
	protected override void Start(){
		base.Start ();
		slider.onValueChanged.AddListener (delegate {
			SoundVolume ();
		});
		LoadValudSound();
	}

	private void LoadValudSound(){
		slider.value = SoundManager.Instance.GetVolume ();
	}
	public void SoundVolume(){
		SoundManager.Instance.SetVolume (slider.value);
	}
}
