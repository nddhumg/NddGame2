using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SoundType{
	PickUpItem = 0,
	Click,
}
[RequireComponent(typeof(AudioSource))]
public class SoundManager : NddBehaviour {
	[SerializeField] protected AudioSource audioFx;

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
	public void OnPlaySound(SoundType soundType){
		
		string resPath = "Sounds/" + soundType.ToString();
		var audio = Resources.Load<AudioClip>(resPath);
		audioFx.PlayOneShot(audio);
	}
//	IEnumerator FadeOutAndPlayNewSound(AudioSource audioSource, AudioClip newClip, float fadeDuration)
//	{
//		float startVolume = audioSource.volume;
//		float timer = 0;
//
//		while (timer < fadeDuration)
//		{
//			timer += Time.deltaTime;
//			audioSource.volume = Mathf.Lerp(startVolume, 0, timer / fadeDuration);
//			yield return null;
//		}
//
//		audioSource.Stop();
//		audioSource.volume = startVolume;
//		audioSource.clip = newClip;
//		audioSource.Play();
//	}

}
