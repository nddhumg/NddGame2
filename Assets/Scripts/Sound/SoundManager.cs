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
	[SerializeField] protected Queue<AudioClip> soundQueue = new Queue<AudioClip>();
	[SerializeField] protected float delayTime = 0.1f;
	[SerializeField] protected bool isPlayCoroutine;

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
		if(audioFx.isPlaying){
			this.AddSoundByQueue(audio);
			if(!isPlayCoroutine){
				StartCoroutine(PlayDelaySoundInQueue(delayTime));
			}
		}
		else{
			audioFx.PlayOneShot(audio);
		}
	}
	protected IEnumerator PlayDelaySoundInQueue(float delay){
		isPlayCoroutine = true;
		while (soundQueue.Count > 0)
        {
			if(audioFx.isPlaying){
				yield return new WaitForSeconds(delay);
			}
            AudioClip nextClip = soundQueue.Dequeue();
            audioFx.clip = nextClip;
            audioFx.Play();
		}
		isPlayCoroutine = false;
	}
	protected void AddSoundByQueue(AudioClip sound){
		soundQueue.Enqueue(sound);
	}
}
