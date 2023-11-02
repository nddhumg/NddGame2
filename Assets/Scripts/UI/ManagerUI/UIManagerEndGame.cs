using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerEndGame : NddBehaviour {
	[SerializeField]protected Text textKill;
	[SerializeField]protected Text textClock;
	[SerializeField] protected Text textStatus;

	void OnEnable(){
		SetUpTextClock ();
		SetUpTextKill ();
		UIManagerGame.Instance.BtnOpenSetting.SetActive (false);
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadTextKill ();
		LoadTextClock ();
		LoadTextStatus ();
	}
	protected virtual void LoadTextKill(){
		if (textKill != null)
			return;
		textKill = transform.Find ("Kill").GetComponentInChildren<Text> ();
		Debug.LogWarning("Add Text Kill",gameObject);
	}
	protected virtual void LoadTextStatus(){
		if (textStatus != null)
			return;
		textStatus = transform.Find ("Status").GetComponent<Text> ();
		Debug.LogWarning("Add Text Status",gameObject);
	}
	protected virtual void LoadTextClock(){
		if (textClock != null)
			return;
		textClock = transform.Find ("Time").GetComponentInChildren<Text> ();
		Debug.LogWarning("Add Text Time",gameObject);
	}
	private void SetUpTextClock(){
		string text = "Time: "+ InRunTime.Instance.ChangeTimerToString(InRunTime.Instance.Timer);
		SetUpText (textClock,text);
	}
	private void SetUpTextKill(){
		string text = "Kill: "+ Achievements.Instance.enemyKill;
		SetUpText (textKill,text);
	}
	private void SetUpText(Text text,string content){
		if (text == null) {
			Debug.LogError ("Text Null", gameObject);
			return;
		}
		text.text = content;
	}
	public void OnClickBtnExitGame(){
		SoundManager.Instance.OnPlaySound (SoundType.Click);
		LoadScene.Instance.LoadSceneByName (SceneName.GameStart);
	}
	public void TextStatusSetup(string status){
		textStatus.text = status;
	}	
}
