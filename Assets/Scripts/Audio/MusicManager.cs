using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MusicName{
	MusicGameStart,
	Battle,
}

[RequireComponent(typeof(AudioSource))]
public class MusicManager : NddBehaviour {
	[SerializeField] private AudioSource audioMusic;
	[SerializeField] private float fadeDuration = 0.5f;
	public float volumMaxMusic  = 1;

	[System.Serializable]
	public class MusicAudioClip
	{
		public MusicName name;
		public AudioClip clip;
	}
	[SerializeField]private MusicAudioClip[] musics;
	private static MusicManager instance;
	public static MusicManager Instance{
		get{
			return instance;
		}
	}
	protected override void Start(){
		base.Start ();
		OnPlayMusic (MusicName.MusicGameStart);
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
		if (this.audioMusic != null)
			return;
		this.audioMusic = GetComponent<AudioSource>();
		Debug.Log("Add AudioSource",gameObject);
	}
	public void OnPlayMusic(MusicName musicType){
		AudioClip audio = null;
		foreach(MusicAudioClip music in musics){
			if (music.name == musicType) {
				audio = music.clip;
				break;
			}
		}
		if (audio == null) {
			Debug.LogError ("Dont Music Name" + musicType, gameObject);
			return;
		}
		if (audioMusic.isPlaying) {
			StartCoroutine (SmoothMusicSwap (audio, fadeDuration));
		} else {
			audioMusic.clip = audio;
			audioMusic.loop = true;
			audioMusic.Play ();
		}
	}
	IEnumerator SmoothMusicSwap(AudioClip audioClip, float fadeDuration){
		float startVolume = audioMusic.volume;
		float startTime = Time.time;

		while (Time.time - startTime < fadeDuration)
		{
			float elapsed = Time.time - startTime;
			audioMusic.volume = Mathf.Lerp(startVolume, 0, elapsed / fadeDuration);
			yield return new WaitForEndOfFrame();
		}

		audioMusic.Stop();
		audioMusic.clip = audioClip;
		audioMusic.loop = true;
		audioMusic.Play();

		startTime = Time.time;

		while (Time.time - startTime < fadeDuration)
		{
			float elapsed = Time.time - startTime;
			audioMusic.volume = Mathf.Lerp(0, volumMaxMusic, elapsed / fadeDuration);
			yield return new WaitForEndOfFrame();
		}

		audioMusic.volume = volumMaxMusic;
	}
	public void Toggle(){
		audioMusic.mute = !audioMusic.mute;
	}
	public void SetVolume(float volume){
		audioMusic.volume = volume;
	}
	public float GetVolume(){
		return audioMusic.volume;
	}
}
