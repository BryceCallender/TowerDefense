using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{
	public float health = 10f;
	public float money = 10f;

	public Text moneyText;
	public Text livesText;

	public GameObject gameOverPanel;
	public GameObject winPanel;
	public GameObject spawner;
	GameObject[] enemiesAlive;

 	private bool gameOver = false;
	private bool restart = false;

	// Use this for initialization
	void Start ()
	{}

	public void LoseLife()
	{
		if (health > 0) 
		{
			health--;
		}
		if (health <= 0) 
		{
			GameOver();
		}
	}
		
	public void GameOver()
	{
		gameOver = true;
		gameOverPanel.SetActive (true);
	}

	public void WinGame()
	{
		winPanel.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () 
	{
		enemiesAlive = GameObject.FindGameObjectsWithTag ("Enemy");
		if (CheckWin ()) 
		{
			WinGame ();
		}
		moneyText.text = "Money: " + money;
		livesText.text = "Lives: " + health;
	}

	bool CheckWin()
	{ 
		int waveCount = spawner.GetComponent<SpawnWaves> ().waveCount;
		int wavesInGame = spawner.GetComponent<SpawnWaves> ().wave.Length;

		int howManyAlive = enemiesAlive.Length;
		if (howManyAlive == 0 && health > 0 && waveCount == wavesInGame) 
		{
			return true;
		} 
		else 
		{
			return false;
		}
	}
}
