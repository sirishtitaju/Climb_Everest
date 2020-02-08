using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UiManager : MonoBehaviour {

	public static UiManager instance;
	public GameObject gameOverPanel;
	public GameObject StartUI;
	public GameObject gameOverText;
	public Text highScoreText;
	public Text scoreText;
	void Awake()
	{
		if (instance == null) {
			instance = this;
		}
	}
	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 300;
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = ScoreManager.instance.score.ToString ();
	}

	public void GameOver(){
		gameOverText.SetActive(true);
		highScoreText.text =  "High Score:\t" + PlayerPrefs.GetInt ("HighScore");
		gameOverPanel.SetActive (true);
	}
	public void Replay()
	{
		SceneManager.LoadScene ("level1");
	}
	public void Menu()
	{
		SceneManager.LoadScene ("Menu");
	}
	public void GameStart()
	{
		StartUI.SetActive (false);
	}
}

