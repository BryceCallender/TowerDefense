using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpot : MonoBehaviour 
{
	void OnMouseDown()
	{
		Debug.Log ("clicked");
		BuildingManager bm = GameObject.FindObjectOfType<BuildingManager> ();
		GameController gc = GameObject.FindObjectOfType<GameController> ();
		int towerCost = 0;

		Debug.Log (bm.selectedTower.tag);
		if(bm.selectedTower.tag == "RegularTower")
		{
			towerCost = bm.selectedTower.GetComponent<Tower>().cost;
		}

		if(bm.selectedTower.tag == "LaserTower")
		{
			towerCost = bm.selectedTower.GetComponent<LaserTower>().cost;
		}


			
		if (bm.selectedTower != null) 
		{
			if(gc.money >= towerCost) 
			{
				gc.money -= towerCost;
				Instantiate (bm.selectedTower, transform.parent.position, transform.parent.rotation);
				Debug.Log (bm.selectedTower.transform.position);
				Destroy (transform.parent.gameObject);
			} 
			else
			{
				Debug.Log ("No Money");
				return;
			}
		}
	}
}
