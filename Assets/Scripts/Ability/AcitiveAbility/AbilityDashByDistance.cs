using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityDashByDistance : ActiveAbility {
	[Header("Dash Ability")]
	[SerializeField] protected Vector2 dashDirection;
	[SerializeField] protected float dashDistance = 3f;
	[SerializeField] protected float dashSpeed = 30f;
	[SerializeField] protected bool conflict = false;
	protected override void Update(){
		base.Update ();
		this.UnannouncedConditions ();
	}
	protected IEnumerator Dash() {
		float distanceTravelled = 0f;
		Vector3 dashDirectionVt3 = new Vector3 (dashDirection.x, dashDirection.y, 0);
		SpawnFXDash ();
		while (distanceTravelled < dashDistance) {
			if (conflict) {
				StopDash ();
				yield break;
			}
			transform.parent.parent.parent.position += dashDirectionVt3.normalized * dashSpeed * Time.deltaTime;
			distanceTravelled += (dashDirectionVt3.normalized * dashSpeed * Time.deltaTime).magnitude;  
			yield return null;
		}
		StopDash ();
		yield return null;
	}

	protected virtual void StopDash(){
		dashDirection = Vector2.zero;
	}
	protected virtual void SpawnFXDash(){
		string nameFx = this.GetNameFx ();
		Vector3 posFxSpawn = transform.position + new Vector3(0,-0.6f,0);
		SpawnFx.Instance.Spawn (nameFx, posFxSpawn,GetRotationFx());
	}
	protected virtual string GetNameFx(){
		return FxName.FxDash.ToString();
	}
	protected virtual Quaternion GetRotationFx(){
		float angleByDirectionAndOx = Mathf.Atan2 (dashDirection.y, dashDirection.x) * Mathf.Rad2Deg;
		Quaternion rotationNew = Quaternion.identity;

		// Rotaion 360 Degree
		if(angleByDirectionAndOx < 90 && angleByDirectionAndOx > -90)
			rotationNew *= Quaternion.Euler(0, 0, angleByDirectionAndOx);
		else 
			rotationNew *= Quaternion.Euler(180, 0, -angleByDirectionAndOx);
		return rotationNew;
	}
	protected virtual void UnannouncedConditions(){
	 // Stop Dash by conflict in runtime
	}
		
}
