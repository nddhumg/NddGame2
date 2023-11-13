using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum SoundName{
	PickUpItem = 0,
	Click,
	LevelUp,
}
[RequireComponent(typeof(AudioSource))]
public class SoundManager : NddBehaviour {
	[SerializeField] protected AudioSource audioFx;
	[System.Serializable]
	public class SoundAudioClip
	{
		public SoundName name;
		public AudioClip clip;
		public SoundAudioClip(SoundName name,AudioClip clip){
			this.name = name;
			this.clip = clip;
		}
	}
	[SerializeField]private List<SoundAudioClip> sounds;
	private static SoundManager instance;
	public static SoundManager Instance{
		get{
			return instance;
		}
	}
	protected override void LoadSingleton() {
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadAudioSource ();
		LoadSounds ();
	}
	protected virtual void LoadSounds(){
		if (sounds.Count > 0)
			return;
		foreach (SoundName enumValue in Enum.GetValues(typeof(SoundName)))
		{
			string stringValue = Enum.GetName(typeof(SoundName), enumValue);
			string resPath = "Audio/Sounds/" + stringValue;
			AudioClip clip = Resources.Load<AudioClip> (resPath);
			SoundAudioClip sound = new SoundAudioClip(enumValue,clip);
			sounds.Add(sound);
		}
		Debug.Log("Add AudioSource",gameObject);
	}
	protected virtual void LoadAudioSource(){
		if (this.audioFx != null)
			return;
		this.audioFx = GetComponent<AudioSource>();
		Debug.Log("Add AudioSource",gameObject);
	}
	public void OnPlaySound(SoundName soundName){
		AudioClip audio = null;
		foreach(SoundAudioClip sound in sounds){
			if (sound.name == soundName) {
				audio = sound.clip;
				break;
			}
		}
		if (audio != null) {
			audioFx.PlayOneShot (audio);
		} else {
			Debug.LogError ("Dont Audio sound " + soundName, gameObject);
		}
	}

	public void Toggle(){
		audioFx.mute = !audioFx.mute;
	}
	public void SetVolume(float volume){
		audioFx.volume = volume;
	}
	public float GetVolume(){
		return audioFx.volume;
	}
}
