using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum SceneName{
	GameStart,
	Play,
}
public class LoadScene : NddBehaviour {
	[SerializeField] protected GameObject imgLoadScene;
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
	protected override void Start ()
	{
		base.Start ();
		this.imgLoadScene.SetActive (false);
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadImgLoadScene ();
	}
	protected virtual void LoadImgLoadScene(){
		if (this.imgLoadScene != null)
			return;
		this.imgLoadScene = GameObject.Find ("ImgLoadScene");
		Debug.Log("Add ImgLoadScene",gameObject);
	}
	public void LoadSceneByName(SceneName sceneName){
		StartCoroutine (this.LoadSceneWithLoading (sceneName));
		Main.Instance.ResumeGame ();
	}
	public void LoadScenePlay(){
		LoadSceneByName (SceneName.Play);
	}
	public void LoadSceneStartGame(){
		LoadSceneByName (SceneName.GameStart);
	}
	IEnumerator LoadSceneWithLoading(SceneName sceneName){
		string scene = sceneName.ToString ();
		imgLoadScene?.SetActive (true);
		yield return new WaitForSeconds (1f);
		AsyncOperation asyncOperation	= SceneManager.LoadSceneAsync (scene);
		Debug.Log (asyncOperation.ToString());
		while (!asyncOperation.isDone) {
//			float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f)
			yield return null;
		}
		imgLoadScene?.SetActive (false);
	}
}
