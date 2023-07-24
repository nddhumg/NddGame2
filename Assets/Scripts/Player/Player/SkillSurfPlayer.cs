using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSurfPlayer : SkillSurfByDistance {
    [Header("SkillSurfPlayer")]
	[SerializeField] protected bool keySkillSurf;
	[SerializeField] protected Vector4 keyMoving;
	[SerializeField] protected float delayTime = 5f;
	[SerializeField] protected float timer = 2f;
	[SerializeField]protected PlayerCtrl playerCtrl;
	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadPlayerCtrl (); 
		this.LoadRigidbody2DParent (playerCtrl.PhysicsPlayer.Rig2d);
	}

	protected virtual void LoadPlayerCtrl(){
		if (this.playerCtrl != null)
			return;
		this.playerCtrl= transform.GetComponentInParent<PlayerCtrl>();
		Debug.Log ("Add PlayerCtrl", gameObject);
	}
	void Update(){
		keyMoving = InputManager.Instance.KeyMoving;
		this.SurfPlayer ();
	}
	protected override void CalculateDirection() {
        
        direction = new Vector2(0, 0);
        if (keyMoving.x == 1) {
            direction.x += 1;
        }
        if (keyMoving.y == 1) {
            direction.x -= 1;
        }
        if (keyMoving.z == 1)
        {
            direction.y -= 1;
        }
        if (keyMoving.w == 1)
        {
            direction.y += 1;
        }
    }

	protected override void StopSurf(){
		base.StopSurf ();
		playerCtrl.AnimationPlayer.SetAnimationSurf (false);
	}
	protected virtual void SurfPlayer(){
		if (distance <= 0) {
			StopSurf ();
		}
		timer += Time.deltaTime;
		this.keySkillSurf = InputManager.Instance.KeySpace;
		if (keySkillSurf && timer >= delayTime && keyMoving != Vector4.zero) {
			playerCtrl.AnimationPlayer.SetAnimationSurf (true);
			CalculateDirection ();
			this.Surf ();
			timer = 0f;
		}
	}

}
