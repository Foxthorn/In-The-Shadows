using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public static LevelManager lm;
	public GameObject title;
	public int numObjects;

	List<string> tags = new List<string>();
	Text t;
	// Use this for initialization
	void Start () {
		if (lm == null)
			lm = this;
		t = title.GetComponent<Text>();
		Scene scene = SceneManager.GetActiveScene();
	}
	
	// Update is called once per frame
	void Update () {
		if (t.fontSize >= 50) {
			Thread.Sleep(1000);
			SceneManager.LoadScene("Level_Won");
			GameManager.gm.finishedLevels.Add(SceneManager.GetActiveScene().name);
		}
		if (tags.Count == numObjects)
		{
			GameManager.gm.busyLoadingLevel = false;
			StartCoroutine(LevelWonTitle());
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

	public void LevelComplete(string tag)
	{
		Debug.Log(tag);
		if (!tags.Contains(tag))
			tags.Add(tag);
	}

	public void RemoveTag(string tag)
	{
		Debug.Log(tag);
		tags.Remove(tag);
	}
}
