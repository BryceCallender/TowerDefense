using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
	public GameObject selectedTower;

	public Text towerText;
	public Text towerCost;
	public Text towerRange;
	public Text towerDamage;

	public Transform panel;
	int cost;
	float damage;
	float range;

	void Start()
	{
//		GameObject a = (GameObject)Instantiate(selectedTower); 
//		a.transform.SetParent(panel.transform,false);
	}

	public void SelectedTower(GameObject towerType) 
	{
		selectedTower = towerType;
		towerText.text = "Current Tower:\n" + selectedTower.name;
		if(selectedTower.tag == "RegularTower")
		{
			cost = selectedTower.GetComponent<Tower>().cost;
			damage = selectedTower.GetComponent<Tower>().damage;
			range = selectedTower.GetComponent<Tower>().range;
		}

		if(selectedTower.tag == "LaserTower")
		{
			cost = selectedTower.GetComponent<LaserTower>().cost;
			damage = selectedTower.GetComponent<LaserTower>().damage;
			range = selectedTower.GetComponent<LaserTower>().range;
		}

		towerCost.text = "Tower Cost: " + cost;
		towerDamage.text = "Tower Damage: " + damage;
		towerRange.text = "Tower Range: " + range;

 	}
}
