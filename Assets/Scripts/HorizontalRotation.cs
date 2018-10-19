using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalRotation : MonoBehaviour {

	public float rotationSpeed = 10f;
	public GameObject shadow;

	float horizontal;
	bool canRotate = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		horizontal = Input.GetAxis("Mouse X");
		var mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Input.GetKeyDown(KeyCode.Mouse0) && !Input.GetKey(KeyCode.LeftControl))
		{
			RaycastHit hit;
			if (Physics.Raycast(mousePosition, out hit))
				if (hit.collider.transform.tag == "Rotate_Object")
					canRotate = true;
				else
					canRotate = false;
		}
		if (canRotate && Input.GetKey(KeyCode.Mouse0))
			RotateObject();
		CheckIfFinished();
		shadow.transform.rotation = transform.rotation;
	}

	void RotateObject()
	{
		transform.Rotate(transform.up * horizontal * rotationSpeed);
	}

	bool CheckIfFinished()
	{
		if (!Input.GetKey(KeyCode.Mouse0))
		{
			if (transform.eulerAngles.y >= GameManager.gm.minRangeY && transform.eulerAngles.y <= GameManager.gm.maxRangeY)
			{
				LevelManager.lm.LevelComplete();	
			}
		}
		return false;
	}
}
