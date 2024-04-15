using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityCircular : PassiveAbility {
	[SerializeField] protected List<Transform> ObjAbility = new List<Transform>();
	[SerializeField] protected GameObject prefab;
	[SerializeField] protected Transform centerPosition;
	[SerializeField] protected Transform holder;
	[SerializeField] protected float radius = 2f;
	[SerializeField] protected float speed = 1f;
	[SerializeField] protected int maxPrefab = 5;
	[SerializeField] protected Vector3 rotationHolder = new Vector3 (0, 0, 0);

	public Transform CenterPosition{
		get{ 
			return centerPosition;
		}
	}
	public float Radius{
		get{ 
			return radius;
		}
		set{ 
			radius = value;
		}
	}
	public float Speed{
		get{ 
			return speed;
		}
		set{ 
			speed = value;
		}	
	}

	protected override void Start ()
	{
		base.Start ();
	}
	void Update(){
		RotateHolder ();
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadPrefab ();
		LoadHolder ();
		LoadCenterPositionCircular ();
	}
	protected virtual void LoadHolder(){
		if (holder != null) {
			return;
		}
		holder = transform.Find ("Holder");
		Debug.LogWarning ("Add Holder", gameObject);
	}
	protected virtual void LoadPrefab(){
		if(prefab != null)
			return;
		prefab = transform.Find ("Prefab").gameObject;
		Debug.LogWarning ("Add prefab", gameObject);
	}
	protected abstract void LoadCenterPositionCircular ();
	public virtual bool InstantiatePrab(){
		if (IsMaxPrefab ()){
			Debug.LogWarning("Maximum obj prefab.Dont Instantiate obj",gameObject);
			return false;
		}
		GameObject newPrefab = Instantiate(prefab);
		newPrefab.transform.parent = holder;
		newPrefab.SetActive (true);
		ObjAbility.Add (newPrefab.transform);
		SetPositionObj();
		return true;
	}
	public virtual void InstantiatePrab(int value){
		for(int temp = 1;temp <= value; temp++){
			if (!InstantiatePrab ()) {
				break;
			}
		}
	}
	protected virtual void RotateHolder(){
		rotationHolder.z += Time.deltaTime * speed * 100;
		if (rotationHolder.z >= 360) {
			rotationHolder.z -= 360;
		}
		holder.localRotation = Quaternion.Euler (rotationHolder);
	}
	private void SetPositionObj(){
		for (int i = 0; i < ObjAbility.Count; i++)
		{
			float angle = i * (360f / ObjAbility.Count) * Mathf.Deg2Rad;
			ObjAbility [i].localPosition = new Vector2 (Mathf.Sin (angle) * radius, Mathf.Cos (angle) * radius);
		}
	}
	protected virtual bool IsMaxPrefab(){
		return ObjAbility.Count >= maxPrefab;
	}

	 
}
