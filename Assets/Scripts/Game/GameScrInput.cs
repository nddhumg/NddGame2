using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScrInput : MonoBehaviour {
	[SerializeField] private Canvas canvasMobi;
	[SerializeField] private Canvas canvasPc;

	void Start(){
		if (MainPlay.Instance.IsMobi) {
			canvasMobi.gameObject.SetActive (true);
			canvasPc.gameObject.SetActive (false);
		} else {
			canvasMobi.gameObject.SetActive (false);
			canvasPc.gameObject.SetActive (true);
		}
	}
}
