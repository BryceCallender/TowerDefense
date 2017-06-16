using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	GameObject pathGO;
	Transform targetPathNode;
	static GameController gameController;
	int pathNodeIndex = 0;
	float speed = 5f;
	public float health = 1f;
	public int moneyValue;

	// Use this for initialization
	void Start () 
	{
		pathGO = GameObject.Find("Path");
	}

	void GetNextPathNode() 
	{
		if(pathNodeIndex < pathGO.transform.childCount) 
		{
			targetPathNode = pathGO.transform.GetChild(pathNodeIndex);
			pathNodeIndex++;
		}
		else 
		{
			targetPathNode = null;
//			ReachedGoal();
		}
	}

	// Update is called once per frame
	void Update () 
	{
		if(targetPathNode == null) 
		{
			GetNextPathNode();
			if(targetPathNode == null) 
			{
				// We've run out of path!
				ReachedGoal();
				return;
			}
		}

		Vector3 dir = targetPathNode.position - this.transform.localPosition;

		float distThisFrame = speed * Time.deltaTime;

		if(dir.magnitude <= distThisFrame)
		{
			// We reached the node
			targetPathNode = null;
		}
		else 
		{
			// Move towards node
			transform.Translate( dir.normalized * distThisFrame, Space.World );
			Quaternion targetRotation = Quaternion.LookRotation( dir );
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime*5);
		}

	}

	void ReachedGoal() 
	{
		Destroy(gameObject);
		GameObject.FindObjectOfType<GameController>().LoseLife();
	}

	public void TakeDamage(float damage)
	{
		health -= damage;
		Debug.Log (health);
		if (health <= 0) 
		{
			Destroy (gameObject);
			GameObject.FindObjectOfType<GameController>().money += moneyValue;
		}
	}

}
