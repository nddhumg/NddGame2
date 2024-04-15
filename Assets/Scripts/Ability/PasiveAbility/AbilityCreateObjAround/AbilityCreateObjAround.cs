using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityCreateObjAround : NddBehaviour {
	[SerializeField] protected int quantityObj = 0;
	[SerializeField] protected Vector2 positionSpawnMax = new Vector2(1f,1f);
	[SerializeField] protected float timeSpawn = 1f;

	public int QuantityObj{
		get{ 
			return quantityObj;
		}
		set{ 
			quantityObj = value;
		}
	}
	public float TimeSpawn{
		get{ 
			return timeSpawn;
		}
		set{ 
			timeSpawn = value;
		}
	}
	protected override void Start ()
	{
		base.Start ();
		StartCoroutine (CreateByTime());
	}
	IEnumerator CreateByTime(){
		while (true) {
			this.CreateObjRandomPosition ();
			yield return new WaitForSeconds (timeSpawn);
		}
	}
		
	protected virtual void CreateObjRandomPosition(){
		for (int i=0; i < quantityObj; i++) {
			Vector3 positionSpawn = GetRandomPositionSpawn ();
			 CreateObj (positionSpawn, Quaternion.identity);
		}
	}
	protected virtual Vector3 GetRandomPositionSpawn(){
		float positionSpawnX = Random.Range (0f, positionSpawnMax.x);
		float positionSpawnY = Random.Range (0f, positionSpawnMax.y);
		if ( Random.Range (0, 2) == 0 ) {
			return transform.position + new Vector3 (positionSpawnX, positionSpawnY, 0f);
		} else {
			return transform.position - new Vector3 (positionSpawnX, positionSpawnY, 0f);
		}
	}
	protected abstract GameObject CreateObj (Vector3 position, Quaternion rotation);
}
