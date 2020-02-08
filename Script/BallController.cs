using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallController : MonoBehaviour {
	public float rotation;
	public float upForce;

	[SerializeField]
	private Rigidbody2D rb;

	[SerializeField]
	private Animator GameOver;
	bool started;
	bool gameOver;
	// Use this for initialization
	void Start () {
		started = false;
		gameOver = false;
		rb.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!started) {
			if (Input.GetMouseButtonDown (0)) {
				started = true;
				rb.isKinematic = false;
				GameManager.instance.GameStart ();
			}
				
		} else if(started && !gameOver) {
			transform.Rotate (0, 0, rotation);
			if (Input.GetMouseButtonDown (0)) {
				rb.velocity = Vector2.zero;
				rb.AddForce(new Vector2(0, upForce));
			}
		}
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		gameOver = true;
		GameManager.instance.GameOver ();

		//GetComponent<Animator> ().Play ("gameOver");
		//GameOver.Play ("gameOver");
		GameOver.SetBool ("GameOver",true);
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Pipe" && !gameOver) {
			gameOver = true;
			GameManager.instance.GameOver ();

			//GetComponent<Animator> ().Play ("gameOver");
			//GameOver.Play ("gameOver");
			GameOver.SetBool ("GameOver",false);

		}
		if (col.gameObject.tag == "ScoreChecker" && !gameOver) {
			ScoreManager.instance.IncrementScore ();
		}
	}
}