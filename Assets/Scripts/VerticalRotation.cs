using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalRotation : MonoBehaviour {

	public float rotationSpeed = 10f;

	float vertical;
	bool canRotate = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		vertical = Input.GetAxis("Mouse Y");
		var mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Input.GetKeyDown(KeyCode.Mouse0) && Input.GetKey(KeyCode.LeftControl))
		{
			RaycastHit hit;
			if (Physics.Raycast(mousePosition, out hit))
				if (hit.collider.transform.tag == transform.tag)
					canRotate = true;
				else
					canRotate = false;
		}
		if (canRotate && Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.LeftControl))
			RotateObject();
		CheckIfFinished();
	}

	void RotateObject()
	{
		transform.eulerAngles = new Vector3(transform.eulerAngles.x + vertical * rotationSpeed, transform.eulerAngles.y, transform.eulerAngles.z);
	}

	bool CheckIfFinished()
	{
		if (!Input.GetKey(KeyCode.Mouse0))
		{
			if (transform.eulerAngles.x >= GameManager.gm.minRangeX && transform.eulerAngles.x <= GameManager.gm.maxRangeX)
			{
				LevelManager.lm.LevelComplete(LevelManager.Direction.x);	
			}
		}
		return false;
	}
}
