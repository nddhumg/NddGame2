using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderMusic : SliderBase {
	
	protected override void Start(){
		base.Start ();
		slider.onValueChanged.AddListener (delegate {
			MusicVolume ();
			MusicManager.Instance.VolumMaxMusic = slider.value;
		});
		LoadValueMusic();
	}
	private void LoadValueMusic(){
		slider.value = MusicManager.Instance.GetVolume ();
	}
	public void MusicVolume(){
		MusicManager.Instance.SetVolume (slider.value);
	}
}
