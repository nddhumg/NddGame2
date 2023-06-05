using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSenderBulletNormal : DamageSenderBullet {
	protected override void Send(DamageReceiver receiver) {
		bulletCtrl.DestroyBullet.DestroyObj ();
		base.Send (receiver);
	}
}
