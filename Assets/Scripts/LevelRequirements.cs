using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRequirements {

	public List<float> max_x_rotations = new List<float>();
	public List<float> min_x_rotations = new List<float>();
	public List<float> min_y_rotations = new List<float>();
	public List<float> max_y_rotations = new List<float>();
	public List<float> max_y_positions = new List<float>();
	public List<float> min_y_positions = new List<float>();
	
	public LevelRequirements() {}

	public void ClearPrevious()
	{
		max_x_rotations.Clear();
		min_x_rotations.Clear();
		min_y_positions.Clear();
		max_y_positions.Clear();
		max_y_rotations.Clear();
		min_y_rotations.Clear();
	}
}
