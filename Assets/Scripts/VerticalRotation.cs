using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalRotation : MonoBehaviour {

	public float rotationSpeed = 10f;
	public int index = 0;

	float vertical;
	bool canRotate = false;
	LevelRequirements l_requirements;
	// Use this for initialization
	void Start () {
		l_requirements = GameManager.gm.l_requirements;
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
			if (transform.eulerAngles.x >= l_requirements.min_x_rotations[index] && transform.eulerAngles.x <= l_requirements.max_x_rotations[index])
			{
				LevelManager.lm.LevelComplete(LevelManager.Direction.x, transform.tag);	
			}
		}
		return false;
	}
}
