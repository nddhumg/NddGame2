using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnhacementSelectAnimation : MonoBehaviour {
	private Sequence sequenceStart;
	private Sequence sequenceEnd;

	private bool isInitializedStart= false, isInitializedEnd = false;
	void Awake(){
		transform.rotation = Quaternion.Euler (new Vector3 (0, 180, 0));
	}
	void OnEnable(){
		if (isInitializedStart == true) {
			sequenceStart.Restart ();
		} else
			AnimationEnable ();
	}
	public void StartAnimationDisable(){
		if (isInitializedEnd == true) {
			sequenceEnd.Restart ();
		} else
			AnimationDisable ();
	}
	private void AnimationEnable(){
		sequenceStart= DOTween.Sequence();
		sequenceStart.SetAutoKill (false)
			.SetUpdate (true);
		sequenceStart.Append(transform.DORotate(new Vector3(0, 90, 0), 0.5f));
		sequenceStart.AppendCallback(() =>
			{
				foreach(Transform tf in transform){
					tf.gameObject.SetActive(true);
				}
			});
		sequenceStart.Append(transform.DORotate(Vector3.zero, 1f));
		isInitializedStart = true;
	}

	private void AnimationDisable(){
		sequenceEnd= DOTween.Sequence();
		sequenceEnd.SetAutoKill (false)
			.SetUpdate (true);
		sequenceEnd.Append(transform.DORotate(new Vector3(0, 90, 0), 0.5f));
		sequenceEnd.AppendCallback(() =>
			{
				foreach(Transform tf in transform){
					tf.gameObject.SetActive(false);
				}
			});
		sequenceEnd.Append(transform.DORotate(new Vector3(0, 180, 0), 1f));
		sequenceEnd.OnComplete(() => UpgradeManager.Instance.DisableUpgradeSelect());
		isInitializedStart = true;
	}
}
