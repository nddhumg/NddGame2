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
	}
	public float Speed{
		get{ 
			return speed;
		}
		set{ 
			speed = value;
		}
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadObjAbility ();
		SetCenterPosition ();
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
	protected abstract void SetCenterPosition ();
	public virtual void InstantiatePrab(){
		if (IsMaxPrefab())
			return;
		GameObject newPrefab = Instantiate(ObjAbility[0].gameObject);
		newPrefab.transform.parent = holder;
		ObjAbility.Add (newPrefab.transform);
		CreateOrbitObj ();
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
