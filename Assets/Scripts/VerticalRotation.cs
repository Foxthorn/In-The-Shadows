using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalRotation : MonoBehaviour {

	public float rotationSpeed = 10f;

	float vertical;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		vertical = Input.GetAxis("Mouse Y");
		var mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.LeftControl))
		{
			RaycastHit hit;
			if (Physics.Raycast(mousePosition, out hit))
				if (hit.collider.transform.tag == "Rotate_Object")
					RotateObject();
		}
	}

	void RotateObject()
	{
		transform.Rotate(transform.forward * vertical * rotationSpeed);
	}
}
