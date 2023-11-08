using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	}
	[SerializeField]private SoundAudioClip[] sounds;
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
