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
	public Text gameOverText;
	public Text winText;
	private bool gameOver = false;
	private bool restart = false;

	// Use this for initialization
	void Start () 
	{
		
	}

	public void LoseLife()
	{
		health--;
		if (health <= 0) 
		{
			GameOver();
		}
	}

	public void WinGame()
	{
		winText.text = "You win!";
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
//		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	
	// Update is called once per frame
	void Update () 
	{
		moneyText.text = "Money: " + money;
		livesText.text = "Lives: " + health;
	}
}
