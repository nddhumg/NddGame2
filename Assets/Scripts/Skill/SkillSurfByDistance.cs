using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSurfByDistance : NddBehaviour {
    [Header("SkillSurf")]
	[SerializeField] protected Rigidbody2D rig;
    [SerializeField] protected float distanceSurf = 5f;
	[SerializeField] protected float distance = 0f;
	[SerializeField] protected Vector2 positionOld;
	[SerializeField] protected Vector2 direction;
	[SerializeField] protected float speedSurf = 10f;

	void FixedUpdate(){
		this.CalculateDistance();
	}

	protected virtual void LoadRigidbody2DParent(Rigidbody2D rigParent){
		if (rig != null)
			return;
		rig = rigParent;
		Debug.Log ("Add Rigidbody2DParent", gameObject);
	}
	protected virtual void CalculateDistance(){
		distance -= Vector3.Distance (positionOld, transform.parent.parent.position);
	}
	protected virtual void CalculateDirection(){
		//override calculate direction
	}
    protected virtual void Surf()
    {
		SpawnFXSurf ();
		this.positionOld = transform.parent.parent.position;
		rig.velocity = direction * speedSurf;

    } 
	protected virtual void SpawnFXSurf(){
		string nameFx = this.GetNameFx ();
		SpawnFx.Instance.Spawn (nameFx, transform.position,GetRotationFx());
	}
	protected virtual string GetNameFx(){
		return SpawnFx.Instance.FxSurf;
	}
	protected virtual Quaternion GetRotationFx(){
		float angleByDirectionAndOx = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
		Quaternion rotationNew = Quaternion.identity;

		// Rotaion 360 Degree
		if(angleByDirectionAndOx < 90 && angleByDirectionAndOx > -90)
			rotationNew *= Quaternion.Euler(0, 0, angleByDirectionAndOx);
		else 
			rotationNew *= Quaternion.Euler(180, 0, -angleByDirectionAndOx);
		return rotationNew;
	}
	protected virtual void StopSurf(){
		direction = Vector2.zero;
		rig.velocity = direction;
		distance = distanceSurf;
	}
}
