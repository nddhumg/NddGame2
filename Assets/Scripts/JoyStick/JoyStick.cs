using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoyStick : NddBehaviour {
	

	[SerializeField] protected RectTransform rectOutLine;
	[SerializeField] protected RectTransform rectPlain;

	[SerializeField] private float radiousOutLine = 0f;
	[SerializeField] private Vector2 mousePos;
	[SerializeField] private Vector2 plainPos;
	[SerializeField] protected Vector2 direction;
	[SerializeField] protected bool isControl = false;

	public Vector2 Direction{
		get{ 
			return direction;
		}
	}

	protected override void Start(){
		radiousOutLine = GetRadiousOutLine ();
	}

	protected virtual void Update(){
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (!isControl && Input.GetMouseButtonDown (0))
			CheckIsControl ();
		PositionPlain ();
	}

	protected override void LoadComponent ()
	{
		LoadRectOutLine();
		LoadRectPlain ();
	}

	private void LoadRectOutLine(){
		if (rectOutLine != null)
			return;
		rectOutLine = transform.GetChild (0).GetComponent<RectTransform>();
		Debug.LogWarning("Load RectOutLine",gameObject);
	}

	protected virtual void EndControl(){
		rectPlain.localPosition = Vector3.zero;
		isControl = false;
		direction = Vector3.zero;
	}

	private void LoadRectPlain(){
		if (rectPlain != null)
			return;
		rectPlain = transform.GetChild (1).GetComponent<RectTransform>();
		Debug.LogWarning("Load RectPlain",gameObject);
	}

	private void CheckIsControl(){
		if (Vector2.Distance (mousePos, transform.position) <= radiousOutLine)
			isControl = true;
	}
		
	private void PositionPlain(){
		if (!isControl)
			return;
		if (Input.GetMouseButtonUp (0)) {
			EndControl ();
			return;
		}
		if (!Input.GetMouseButton (0)) {
			return;
		}
		direction.x = mousePos.x - transform.position.x;
		direction.y = mousePos.y - transform.position.y;
		direction = direction.normalized;
		if (Vector2.Distance (transform.position, mousePos) >= radiousOutLine) {
			rectPlain.position = (Vector2)transform.position + (radiousOutLine * direction);
		} else {
			rectPlain.position = mousePos;
		}
	}

	private float GetRadiousOutLine(){
		Vector3[] woldCorners = new Vector3[4];
		rectOutLine.GetWorldCorners (woldCorners);
		return Vector3.Distance(woldCorners [0] , woldCorners [3])/2;
	}

}
