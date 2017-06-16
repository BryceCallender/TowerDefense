using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectInput : MonoBehaviour 
{
	public EventSystem eventSystem;
	public GameObject selected;

	private bool buttonSelected = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetAxisRaw ("Vertical") != 0 && buttonSelected == false) 
		{
			buttonSelected = true;
			eventSystem.SetSelectedGameObject (selected);
		}
	}

	private void OnDisable()
	{
		buttonSelected = false;
	}
}
