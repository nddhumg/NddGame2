using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgSenderBulletPiercing : DmgSenderBullet {
	public override void Send(DamageReceiver receiver) {
		receiver?.Receiver(this.damage);
		SpawnDamagePopUp (receiver.transform.position);
	}
}
