using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum SceneName{
	GameStart,
	Play,

}
public class LoadScene : NddBehaviour {
	[SerializeField] private Animator animLoadScene;
	[SerializeField] private float timeDelayAnimation = 1f;
	private static LoadScene instance;
	public static LoadScene Instance{
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

	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadAnimLoadScene ();
	}
	protected virtual void LoadAnimLoadScene(){
		if (animLoadScene != null)
			return;
		animLoadScene = transform.GetComponentInChildren<Animator> ();
		Debug.LogWarning ("Add Animator Load Scene", gameObject);
	}
	public void LoadSceneByName(SceneName sceneName){
		StartCoroutine (this.LoadSceneWithLoading (sceneName));
		MainPlay.Instance.ResumeGame ();
	}
	public void LoadScenePlay(){
		LoadSceneByName (SceneName.Play);
		MusicManager.Instance.OnPlayMusic (MusicName.Battle);
	}
	public void LoadSceneStartGame(){
		LoadSceneByName (SceneName.GameStart);
		MusicManager.Instance.OnPlayMusic (MusicName.MusicGameStart);
	}
	IEnumerator LoadSceneWithLoading(SceneName sceneName){
		string scene = sceneName.ToString ();
		animLoadScene.SetTrigger("Start");
		yield return new WaitForSeconds (timeDelayAnimation);
		AsyncOperation asyncOperation	= SceneManager.LoadSceneAsync (scene);
		while (!asyncOperation.isDone) {
			yield return null;
		}
		animLoadScene.SetTrigger("End");
	}
}
