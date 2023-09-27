using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityShotPlayer : AbilityShot,ISetDamagePlayer{
	[Header ("Shot Ability Player")]  
	[SerializeField] protected bool shotByKey ;
	[SerializeField] protected bool shotByAutoPosTarget = true;
	[SerializeField] protected int keyShot;
	[SerializeField] protected float ranShotBullet1 =0.05f;
	[SerializeField] protected PlayerCtrl playerCtrl;
	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadPlayerCtrl (); 
	}
	protected override void Start(){
		base.Start ();
		playerCtrl.AttributesPlayer.AddObsever (this);
	}
	public void OnSetDamage(float damage){
		this.damage = damage;
	}
	protected virtual void LoadPlayerCtrl(){
		if (this.playerCtrl != null)
			return;
		this.playerCtrl=ability.ObjectCtrl as PlayerCtrl;
		Debug.LogWarning ("Add PlayerCtrl", gameObject);
	}
	protected override void ResetValueComponent(){
		base.ResetValueComponent ();
		this.damage = playerCtrl.AttributesPlayer.Damage;
	}
	protected override void ResetValue ()
	{
		base.ResetValue ();
		this.delayAbility = 0.6f;
	}
	protected override void Update(){
		base.Update ();
		this.Shooting ();
	}

	protected virtual void GetKeyShot(){
		keyShot = (int)InputManager.Instance.DownMouse.x;
	}
	protected virtual void Shooting(){
		if (!isReady )
			return;
		if (this.shotByKey) {
			GetKeyShot ();
			if (keyShot != 1)
				return;
		}
		timerAbility = 0f;
		Vector3 PosSpawn = transform.position + new Vector3 (0, 0, 0);
		ShootBullet(PosSpawn);
	}

	protected override string GetNameBullet(){
		float ran= Random.Range (0, 1f);
		if (ran > ranShotBullet1) {
			return playerCtrl.PlayerSO.nameBullets[1];
		} else {
			return playerCtrl.PlayerSO.nameBullets[0];
		}
	}
	protected override void SetBulletTarget(){
		if (this.shotByKey || this.shotByAutoPosTarget) {
			firingDirection = InputManager.Instance.PosMouse;
		}
		firingDirection -= transform.position;
		firingDirection = new Vector3(firingDirection.x,firingDirection.y, 0);
	}
	public virtual void SetStyleShootingPlayer(int style){
		if (style == 0) {
			this.shotByKey = true;
			this.shotByAutoPosTarget = false;

		} else if (style == 1) {
			this.shotByKey = false;
			this.shotByAutoPosTarget = true;

		}
		else {
			Debug.LogError ("Not style shooting play: " + style, gameObject);
		}
	}
	protected override Quaternion SetBulletRotation(Vector3 target){
		Quaternion rotNew = Quaternion.identity;
		float newRotz =  Vector3.SignedAngle (target, Vector3.right,Vector3.forward);
		rotNew *= Quaternion.Euler (0, 0,-newRotz);
		return rotNew;

	}
}
