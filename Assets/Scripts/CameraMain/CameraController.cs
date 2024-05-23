using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : NddBehaviour {
	private static CameraController instance;
	public static CameraController Instance{
		get{ 
			return instance;
		}
	}
	protected override void LoadSingleton() {
		if (CameraController.instance != null) {
			Debug.LogError("Only 1 CameraController allow to exist");

		}
		CameraController.instance = this;
	}
	[SerializeField] protected GameObject GameObjCamera;

	public IEnumerable Shake(float duration, float magnitude){
		float elapsed = 0f;
		Vector2 positionShake = Vector2.zero;
		Vector2 positionOrigin = transform.localPosition;
		while (elapsed < duration) {
			float x = Random.Range(-1f, 1f) * magnitude;
			float y = Random.Range (-1f, 1f) * magnitude;
			positionShake.x = x;
			positionShake.y = y;
			transform.localPosition = positionShake;
			elapsed += Time.deltaTime;
			yield return null;
		}
		transform.localPosition = positionOrigin;
	}
}
