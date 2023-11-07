using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class UIManagerSetting : UIBehaviour {
	[SerializeField] private Slider sliderMusic;
	[SerializeField] private Slider sliderSound;
	protected override void ResetValue ()
	{
		base.ResetValue ();
		speedAnimation = 0.3f;
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadSliderSound ();
		LoadSliderMusic ();
	}
	private void LoadSliderMusic(){
		if (sliderMusic != null)
			return;
		sliderMusic = transform.Find ("Music").GetComponentInChildren<Slider>();
		Debug.LogWarning ("Add Slider Music", gameObject);
	}
	private void LoadSliderSound(){
		if (sliderMusic != null)
			return;
		sliderSound = transform.Find ("Sound").GetComponentInChildren<Slider>();
		Debug.LogWarning ("Add Slider Sound", gameObject);
	}
	protected override void OnEnable(){
		base.OnEnable ();
		UIManagerGame.Instance.BtnOpenSetting.SetActive (false);
	}
	void OnDisable(){
		UIManagerGame.Instance.BtnOpenSetting.SetActive (true);
	}
	void FixedUpdate(){
		bool keyOpenSetting = InputManager.Instance.KeyEsc;
		if (keyOpenSetting && gameObject.activeSelf)
			OnClickCloseSetting ();
	}
	protected override void Appear(){
		transform.localPosition = startAppear;
		Tween tween = rect.DOAnchorPos (endAppear, speedAnimation, false);
		tween.SetUpdate (true);
	}
	public void OnClickExit(){
		SoundManager.Instance.OnPlaySound (SoundType.Click);
		UIManagerGame.Instance.UiExitGame.SetActive (true);
	}
	public void OnClickCloseSetting(){
		SoundManager.Instance.OnPlaySound (SoundType.Click);
		UIManagerGame.Instance.IsOpenUIGame = false;
		MainPlay.Instance.ResumeLastGame ();
		gameObject.SetActive (false);
	}
	public void ToggleMusic(){
		MusicManager.Instance.Toggle ();
	}
	public void ToggleSound(){
		SoundManager.Instance.Toggle ();
	}
	public void SoundVolume(){
		SoundManager.Instance.SetVolume (sliderSound.value);
	}
	public void MusicVolume(){
		MusicManager.Instance.SetVolume (sliderMusic.value);
	}
}
