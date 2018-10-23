using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public static LevelManager lm;
	public GameObject title;

	bool x_rot = false;
	bool y_rot = false;
	bool y_pos = false;
	Text t;
	// Use this for initialization
	void Start () {
		if (lm == null)
			lm = this;
		t = title.GetComponent<Text>();
		Scene scene = SceneManager.GetActiveScene();
		if (scene.name == "lvl_1")
		{
			x_rot = true;
			y_pos = true;
		}
		else if (scene.name == "lvl_2")
		{
			y_pos = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (t.fontSize >= 50) {
			SceneManager.LoadScene("Level_Won");
		}
	}

	IEnumerator LevelWonTitle()
	{
		while(t.fontSize < 50)
		{
			t.fontSize += 1;
			yield return null;
		}
	}

	public void LevelComplete(Direction dir)
	{
		if (dir == Direction.x)
			x_rot = true;
		else if (dir == Direction.y)
			y_rot = true;
		else
			y_pos = true;
		if (x_rot && y_rot && y_pos)
			StartCoroutine(LevelWonTitle());
	}

	public enum Direction
	{
		x = 0,
		y = 1,
		y_pos = 2,
	}
}
