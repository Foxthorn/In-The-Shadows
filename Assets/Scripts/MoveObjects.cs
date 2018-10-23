using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour {

	public float speed;
	public GameObject shadow;
	public int index = 0;

	bool canMove;
	float vertical;
	LevelRequirements l_requirements;
	void Start () {
		l_requirements = GameManager.gm.l_requirements;
	}
	
	// Update is called once per frame
	void Update () {
		vertical = Input.GetAxis("Mouse Y");
		var mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Input.GetKeyDown(KeyCode.Mouse0) && Input.GetKey(KeyCode.LeftAlt))
		{
			RaycastHit hit;
			if (Physics.Raycast(mousePosition, out hit))
				if (hit.collider.transform.tag == transform.tag)
					canMove = true;
				else
					canMove = false;
		}
		if (canMove && Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.LeftAlt))
			MoveObject();
		Debug.Log(l_requirements.min_y_positions[index]);
		shadow.transform.position = new Vector3(transform.position.x - 7f, transform.position.y + 0.3f, transform.position.z - 3f);		
	}

	void MoveObject()
	{
		transform.Translate(transform.up * vertical * speed);
	}

	bool CheckIfFinished()
	{
		if (!Input.GetKey(KeyCode.Mouse0))
		{
			if (transform.eulerAngles.y >= l_requirements.min_y_positions[0] && transform.eulerAngles.y <= l_requirements.max_y_positions[0])
			{
				Debug.Log("POS");
				LevelManager.lm.LevelComplete(LevelManager.Direction.y_pos);	
			}
		}
		return false;
	}
}
