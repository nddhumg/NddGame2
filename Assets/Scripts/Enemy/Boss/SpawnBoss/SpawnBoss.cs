using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnBoss : SpawnNdd {
	[Header("Boss Spawn")]

	[SerializeField] protected float delayMinutesSpawn = 3f;
	[SerializeField] protected float timeStartMinutesSpawn = 2.5f;
	[SerializeField] protected EnemyName[] arrayBoss;
	[SerializeField] protected SODataBossSpawn SOArrayBoss;


	[SerializeField] private GameObject healthBar;
	[SerializeField] private Transform canvasHealthBar;
	[SerializeField] private int numberOfBoss;
	[SerializeField] private int numberOfCurrentBoss = 0;
	 

	private int bossNumber = 0;

	private static SpawnBoss instance;
	public static SpawnBoss Instance{
		get{
			return instance;
		}
	}
	protected override void Start ()
	{
		base.Start ();
		StartCoroutine (SpawnDelay());
	}
	protected override void LoadSingleton() {
		if (SpawnBoss.instance != null) {
			Debug.LogError ("Only 1 SpawnBoss allow to exist");
		}
		SpawnBoss.instance = this;
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadSOArrayBoss ();
		LoadArrayBoss ();
	}
	protected virtual void LoadArrayBoss(){
		if (arrayBoss.Length > 0)
			return;
		if (SOArrayBoss == null) {
			Debug.LogError ("Null SO", gameObject);
			return;
		}
		arrayBoss = SOArrayBoss.bossName;
		numberOfBoss = arrayBoss.Length;
		Debug.LogWarning ("Add ArrayBoss", gameObject);
	}
	protected virtual void LoadSOArrayBoss(){
		if (SOArrayBoss != null)
			return;
		string resPath = "ScriptableObject/Spawn/Boss/" + "SpawnBoss";
		SOArrayBoss = Resources.Load<SODataBossSpawn> (resPath);
		Debug.LogWarning ("Add SO ArrayBoss", gameObject);
	}
	public void Destroy(Transform tf){
		tf.gameObject.SetActive (false);
		numberOfCurrentBoss--;
		StartCoroutine (CheckFinalGame ());
	}
	IEnumerator SpawnDelay(){ 
		while (true) {
			if (InRunTime.Instance.TimeInMinutes < timeStartMinutesSpawn) {
				yield return new WaitForSeconds (1f);
			} 
			else {
				Transform boss = Spawn (GetNameBossSpawn (), SpawnEnemyPoint.Instance.GetRandomPoinSpawn ().position, Quaternion.identity);
				if (boss == null) {
					Debug.Log ("Stop Spawn Boss", gameObject);
					yield break;
				}
				bossNumber++;
				timeStartMinutesSpawn += delayMinutesSpawn;
				yield return new WaitForSeconds (1f);
			}
		}
	}
	public override Transform Spawn(string namePrefab, Vector3 pos, Quaternion rot){
		Transform boss = base.Spawn (namePrefab, pos, rot);
		if (healthBar == null) {
			Debug.LogWarning ("Health Bar Boss Null",gameObject);
			return boss;
		}
		if (boss != null) {
			SpawnHeathBarBoss (boss);
			numberOfCurrentBoss++;
		}
		return boss;
	}
	private void SpawnHeathBarBoss(Transform boss){
		GameObject barBoss= Instantiate (healthBar);
		barBoss.GetComponent<HealthBarBoss> ().SetEnemyCtrl (boss.GetComponent<BossCtrl>());
		barBoss.transform.SetParent(canvasHealthBar,false);
	}
	protected virtual string GetNameBossSpawn(){
		string nameBoss = null;
		try{
			nameBoss = arrayBoss[bossNumber].ToString();
		}
		catch
		{
			
		}
		return nameBoss;	
	}
	IEnumerator  CheckFinalGame(){
		yield return new WaitForSeconds (1);
		if(numberOfCurrentBoss <= 0 && TheFinalBossHasSpawned() ){
			UIManagerPlay.Instance.UIFinal.SetActive (true);
		}
	}
	private bool TheFinalBossHasSpawned(){
		return numberOfBoss >= bossNumber-1;
	}
	public bool debug;
	void Update(){
		if (debug) {
			UIManagerPlay.Instance.UIFinal.SetActive (true);
			debug = false;
		}
	}
}
