using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalRotation : MonoBehaviour {

	public float rotationSpeed = 10f;
	[HideInInspector] public float maxRangeY = 0f;
	[HideInInspector] public float minRangeY = 0f;
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
				if (hit.collider.transform.tag == "Rotate_Object")
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
			if (transform.eulerAngles.y >= minRangeY && transform.eulerAngles.y <= maxRangeY)
			{
				Debug.Log("Level Finished");	
			}
		}
		return false;
	}
}
