using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgSenderBulletPiercing : DmgSenderBullet {
	protected override void Send(DamageReceiver receiver) {
		receiver?.Receiver(this.damage);
	}
}
