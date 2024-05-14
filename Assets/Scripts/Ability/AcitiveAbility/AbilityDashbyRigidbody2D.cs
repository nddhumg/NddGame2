using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDashbyRigidbody2D : ActiveAbility {
	[Header("Dash Ability")]
	[SerializeField] protected Vector2 dashDirection;
	[SerializeField] protected float dashDistance = 3f;
	[SerializeField] protected LayerMask dashLayerMask;

	protected virtual void Dash(){
		Vector3 dashPosition = new Vector3 (transform.position.x + dashDirection.x * dashDistance, transform.position.y + dashDirection.y * dashDistance, 0);
		RaycastHit2D ray = Physics2D.Raycast (transform.position, dashDirection, dashDistance,dashLayerMask);
		if (ray.collider != null) {
			dashPosition = ray.point;
		}
		transform.root.position = dashPosition;
	}
}
