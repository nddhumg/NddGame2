using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameStartManager : NddBehaviour{
	protected override void Start(){
		base.Start ();
		MusicManager.Instance.OnPlayMusic (MusicType.MusicGameStart);
	} 
	public virtual void OnClickStartGame(){
		SoundManager.Instance.OnPlaySound (SoundType.Click);
		MusicManager.Instance.OnPlayMusic (MusicType.Battle);

		LoadScene.Instance.LoadScenePlay ();
	}
}
