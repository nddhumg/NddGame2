using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityShotEnemy : AbilityShot {
	[Header("Shot Enemy")]
	[SerializeField] protected EnemyCtrl enemyCtrl;
	[SerializeField] protected SONameBulletShot nameBulletSO;

	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadEnemyCtrl();
	}
	protected virtual void LoadEnemyCtrl(){
		if (this.enemyCtrl != null)
			return;
		this.enemyCtrl = transform.parent.parent.parent.GetComponent<EnemyCtrl>();
		Debug.LogWarning ("Add EnemyCtrl", gameObject);
	}
	protected override void ResetValue(){
		base.ResetValue ();
		this.delayAbility = 2f;
	}
	protected override void ResetValueComponent ()
	{
		base.ResetValueComponent ();
		this.damage = enemyCtrl.EnemySO.damage;
	}
	protected override string GetNameBullet(){
		if (nameBulletSO == null) {
			Debug.LogError("Null SONameBulletShot",gameObject);
			return null;
		}
		return nameBulletSO.bulletName.ToString();
	}
	protected override void SetBulletTarget(){
		Vector3 targetPosition = Player.Instance.GetPosition();
		firingDirection = targetPosition;
		firingDirection -= transform.position;
		firingDirection = new Vector3(firingDirection.x,firingDirection.y, 0);
	}
	protected override Quaternion SetBulletRotation(Vector3 target){
		Quaternion rotNew = Quaternion.identity;
		float newRotz =  Vector3.SignedAngle (target, Vector3.right,Vector3.forward);
		rotNew *= Quaternion.Euler (0, 0,-newRotz);
		return rotNew;

	}
}
