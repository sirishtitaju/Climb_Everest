using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour {

	public float speed;
	public float upDownSpeed;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 300;
		rb = GetComponent<Rigidbody2D> ();
		Movepipe ();
		InvokeRepeating ("SwitchUpDown", 0.5f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Movepipe(){
		rb.velocity = new Vector2 (-speed, upDownSpeed);
	}
	void SwitchUpDown()
	{
		upDownSpeed = -upDownSpeed;
		rb.velocity = new Vector2 (-speed, upDownSpeed);
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "PipeRemover") {
			Destroy (gameObject);
		}
	}
}
