using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour {
	public float maxYpos;
	public float SpawnTime;
	public GameObject pipe;
	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 300;
		//StartSpawningPipes ();
	}

	// Update is called once per frame
	void Update () {
		
	}
	public void StopSpawingPipes()
	{
		CancelInvoke ("SpawnPipe");
	}
	public void StartSpawningPipes(){
		InvokeRepeating ("SpawnPipe", 0.2f, SpawnTime);
	}

	void SpawnPipe()
	{
		Instantiate (pipe, new Vector3 (transform.position.x, Random.Range (-maxYpos+3.5f, maxYpos+5), 0), Quaternion.identity);
	}
}
