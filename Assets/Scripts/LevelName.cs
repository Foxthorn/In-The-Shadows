using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelName : MonoBehaviour {

	string levelName = "";
	Text title;
	// Use this for initialization
	void Start () {
		title = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
			if (hit.collider.transform.tag == "lvl_1")
				levelName = "Tea Time";
			if (hit.collider.transform.tag == "lvl_2")
				levelName = "Troublesome Trumpet";
			if (hit.collider.transform.tag == "lvl_3")
				levelName = "";
		title.text = levelName;
		levelName = "";
	}
}
