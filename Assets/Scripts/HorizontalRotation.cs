using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalRotation : MonoBehaviour {

	public float rotationSpeed = 10f;
	public int index = 0;
	public GameObject shadow;

	float horizontal;
	bool canRotate = false;
	LevelRequirements l_requirements;
	// Use this for initialization
	void Start () {
		l_requirements = GameManager.gm.l_requirements;
	}
	
	// Update is called once per frame
	void Update () {
		horizontal = Input.GetAxis("Mouse X");
		var mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Input.GetKeyDown(KeyCode.Mouse0) && !Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.LeftAlt))
		{
			RaycastHit hit;
			if (Physics.Raycast(mousePosition, out hit))
				if (hit.collider.transform.tag == transform.tag)
					canRotate = true;
				else
					canRotate = false;
		}
		if (canRotate && Input.GetKey(KeyCode.Mouse0) && !Input.GetKey(KeyCode.LeftControl))
			RotateObject();
		CheckIfFinished();
		shadow.transform.rotation = transform.rotation;
	}

	void RotateObject()
	{
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + horizontal * rotationSpeed, transform.eulerAngles.z);
	}

	public bool CheckIfFinished()
	{
		if (!Input.GetKey(KeyCode.Mouse0))
		{
			if (transform.eulerAngles.y >= l_requirements.min_y_rotations[index] && transform.eulerAngles.y <= l_requirements.max_y_rotations[index])
				return true;
			else if (transform.eulerAngles.y > 180f)
			{
				if (transform.eulerAngles.y <= 340f - l_requirements.max_y_rotations[index] && transform.eulerAngles.y <= 340f - l_requirements.min_y_rotations[index])
					return true;
			}
		}
		return false;
	}
}
