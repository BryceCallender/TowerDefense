using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WaveComponents
{
	public GameObject enemy;
	public int enemyPerWave;
	[System.NonSerialized]
	public int spawned = 0;
}


public class SpawnWaves : MonoBehaviour
{
	public WaveComponents[] wave;
	public int waveCount;
	public float startWait;
	public float waveWait;

	public Text waveText;
	public Text readyUp;

	bool buttonPressed = false;

	float spawnCD = 0.35f;
	float spawnCDRemaining = 0f;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKey(KeyCode.R)) 
		{
			readyUp.text = "";
			buttonPressed = true;
		}
		if (buttonPressed) 
		{
			spawnCDRemaining -= Time.deltaTime;
			if (spawnCDRemaining <= 0)
			{
				spawnCDRemaining = spawnCD;
				StartCoroutine (SpawnWave ());
			}
		}
	}

	IEnumerator SpawnWave()
	{
		yield return new WaitForSeconds (startWait);
		foreach (WaveComponents w in wave) 
		{
			if (w.spawned < w.enemyPerWave) 
			{
				Debug.Log ("Spawned Enemy");
				Instantiate (w.enemy, this.transform.position, this.transform.rotation);
				w.spawned++;
				if (w.spawned == w.enemyPerWave) 
				{
					waveCount++;
					waveText.text = "Wave: " + waveCount; 		
				}
				break;
			} 
			yield return new WaitForSeconds (waveWait);
		}
	}
}
