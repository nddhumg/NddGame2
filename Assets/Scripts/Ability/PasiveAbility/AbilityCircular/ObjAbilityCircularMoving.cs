using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjAbilityCircularMoving : NddBehaviour {
	[SerializeField]protected AbilityCircular abilityCircular;
//	private float angle = 0f;
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadAbilityCircular ();
	}
//	public virtual void SetAngle(float newAngle){
//		angle = newAngle;
//	}
	protected virtual void LoadAbilityCircular(){
		if (this.abilityCircular != null)
			return;
		this.abilityCircular= transform.parent.parent.parent.GetComponent<AbilityCircular>();
		Debug.LogWarning ("Add AbilityCircular", gameObject);
	}
	void Update(){
//		float x = abilityCircular.CenterPosition.position.x + Mathf.Cos (angle) * abilityCircular.Radius;
//		float y = abilityCircular.CenterPosition.position.y + Mathf.Sin (angle) * abilityCircular.Radius;
//		transform.parent.position = new Vector2 (x, y);
//		angle += abilityCircular.Speed * Time.deltaTime;
		transform.parent.localRotation = Quaternion.identity;
	}
}
