using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public static LevelManager lm;
	public GameObject title;

	Text t;
	// Use this for initialization
	void Start () {
		if (lm == null)
			lm = this;
		t = title.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (t.fontSize >= 50)
			SceneManager.LoadScene("Level_Won");
	}

	IEnumerator LevelWonTitle()
	{
		while(t.fontSize < 50)
		{
			t.fontSize += 1;
			yield return null;
		}
	}

	public void LevelComplete()
	{
		StartCoroutine(LevelWonTitle());
	}
}
