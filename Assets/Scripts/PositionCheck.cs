using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCheck : MonoBehaviour {
	
	HorizontalRotation horizontal;
	VerticalRotation vertical;
	MoveObjects position;
	bool hori;
	bool vert;
	bool pos;
	// Use this for initialization
	void Start () {
		horizontal = GetComponent<HorizontalRotation>();
		vertical = GetComponent<VerticalRotation>();
		position = GetComponent<MoveObjects>();
		if (horizontal == null)
			hori = true;
		if (vertical == null)
			vert = true;
		if (position == null)
			pos = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (vertical != null)
			vert = vertical.CheckIfFinished();
		if (horizontal != null)
			hori = horizontal.CheckIfFinished();
		if (position != null)
			pos = position.CheckIfFinished();
		if (hori && vert && pos)
			LevelManager.lm.LevelComplete(transform.tag);
		else
			LevelManager.lm.RemoveTag(transform.tag);
	}
}
