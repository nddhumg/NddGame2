using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityCircular : PassiveAbility {
	[SerializeField] protected List<Transform> ObjAbility = new List<Transform>();
	[SerializeField] protected Transform centerPosition;
	[SerializeField] protected Transform holder;
	[SerializeField] protected float radius = 2f;
	[SerializeField] protected float speed = 1f;
	[SerializeField] protected int maxPrefab = 4;

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
		}	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadObjAbility ();
		SetCenterPositionCircular ();
	}
	protected virtual void LoadObjAbility(){
		if (this.ObjAbility.Count != 0)
			return;
		holder= transform.Find("Holder");
		if (holder == null) {
			Debug.LogError ("Not holder in Ability Circular", gameObject);
			return;
		}
		foreach(Transform obj in holder){
			ObjAbility.Add (obj);
		}
		Debug.LogWarning ("Add Prefab", gameObject);
	}
	protected abstract void SetCenterPositionCircular ();
	public virtual bool InstantiatePrab(){
		if (IsMaxPrefab())
			return false;
		GameObject newPrefab = Instantiate(ObjAbility[0].gameObject);
		newPrefab.transform.parent = holder;
		ObjAbility.Add (newPrefab.transform);
		CreateOrbitObj ();
		return true;
	}
	public virtual void InstantiatePrab(int value){
		for(int temp = 1;temp <= value; temp++){
			if (!InstantiatePrab ()) {
				break;
			}
		}
	}
	private void CreateOrbitObj(){
		for (int i = 0; i < ObjAbility.Count; i++)
		{
			float angle = i * (360f / ObjAbility.Count) * Mathf.Deg2Rad;
			ObjAbilityCircularMoving objAbilityCircular = ObjAbility [i].GetComponentInChildren<ObjAbilityCircularMoving> ();
			objAbilityCircular.SetAngle (angle);
		}
	}
	protected virtual bool IsMaxPrefab(){
		return ObjAbility.Count >= maxPrefab;
	}

}
