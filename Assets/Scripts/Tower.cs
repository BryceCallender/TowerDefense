using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour 
{
	Transform turrentTransform;
	public GameObject bulletPrefab;
	public float range = 10f;

	public int cost = 5;

	float fireCooldown = 0.5f;
	float fireCooldownLeft = 0;

	public float damage = 1f;

	// Use this for initialization
	void Start ()
	{
		//Find the transform for the object called Turret
		turrentTransform = transform.Find("Turret");
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Array of game objects created based on how many enemies exist
		Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();

		Enemy nearestEnemy = null;
		float distance = Mathf.Infinity;

		foreach (Enemy e in enemies) 
		{
			float d = Vector3.Distance (this.transform.position, e.transform.position);
			if (nearestEnemy == null || d < distance) 
			{
				nearestEnemy = e;
				distance = d;
			}
		}
		if (nearestEnemy == null)
		{
			Debug.Log ("No Enemies");
			return;
		}

		Vector3 direction = nearestEnemy.transform.position - this.transform.position;
		Quaternion lookRot = Quaternion.LookRotation (direction);
		turrentTransform.rotation = Quaternion.Euler(0,lookRot.eulerAngles.y,0);
		fireCooldownLeft -= Time.deltaTime;
		if(fireCooldownLeft <= 0 && direction.magnitude <= range) 
		{
			fireCooldownLeft = fireCooldown;
			ShootAt(nearestEnemy);
		}
	}

	void ShootAt(Enemy nearestEnemy)
	{
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);

		Bullet b = bulletGO.GetComponent<Bullet>();
		b.target = nearestEnemy.transform;
		b.damage = damage;
	}
	
}
