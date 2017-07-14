using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTower : MonoBehaviour 
{
	public Transform turrentEnd; 
	Transform turrentTransform;

	public GameObject bulletPrefab;

	public float range = 10f;
	public int cost = 5;

	float fireCooldown = 1.5f;
	float fireCooldownLeft = 0;

	public float damage = 2f;

	private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
	private LineRenderer laserLine; 

	// Use this for initialization
	void Start ()
	{
		//Find the transform for the object called Turret
		turrentTransform = transform.Find ("Turret");
		//Gets the componentes for line renderer
		laserLine = GetComponent<LineRenderer>();
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

		Vector3 rayOrigin = turrentEnd.transform.position;
		Vector3 direction = nearestEnemy.transform.position - this.transform.position;
		Quaternion lookRot = Quaternion.LookRotation (direction);
		turrentTransform.rotation = Quaternion.Euler(0,lookRot.eulerAngles.y,0);
		fireCooldownLeft -= Time.deltaTime;
		if(fireCooldownLeft <= 0 && direction.magnitude <= range) 
		{
			laserLine.SetPosition (0, rayOrigin);
			laserLine.SetPosition (1, nearestEnemy.transform.position);
			fireCooldownLeft = fireCooldown;
			StartCoroutine(ShotEffect());
			DamageEnemy (nearestEnemy);

		}
	}

	void DamageEnemy(Enemy nearestEnemy)
	{
		Bullet b = bulletPrefab.GetComponent<Bullet>();
		b.target = nearestEnemy.transform;
		b.damage = damage;
		nearestEnemy.TakeDamage (damage);
	}

	private IEnumerator ShotEffect()
	{
		// Turn on our line renderer
		laserLine.enabled = true;

		//Wait for .07 seconds
		yield return shotDuration;

		// Deactivate our line renderer after waiting
		laserLine.enabled = false;
	}
}

