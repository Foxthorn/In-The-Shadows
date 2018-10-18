using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalRotation : MonoBehaviour {

	public float rotationSpeed = 10f;
	[HideInInspector] public float maxRange = 100f;
	[HideInInspector] public float minRange = 85f;

	float horizontal;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		horizontal = Input.GetAxis("Mouse X");
		var mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Input.GetKey(KeyCode.Mouse0) && !Input.GetKey(KeyCode.LeftControl))
		{
			RaycastHit hit;
			if (Physics.Raycast(mousePosition, out hit))
				RotateObject();
		}
		CheckIfFinished();
	}

	void RotateObject()
	{
		transform.Rotate(transform.up * horizontal * rotationSpeed);
	}

	public bool CheckIfFinished()
	{
		if (!Input.GetKey(KeyCode.Mouse0))
		{
			if (transform.eulerAngles.y >= minRange && transform.eulerAngles.y <= maxRange)
			{
				Debug.Log("Level Finished");	
			}
		}
		return false;
	}
}
