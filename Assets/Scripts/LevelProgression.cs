using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgression : MonoBehaviour {

	public string lvl;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator LoadLevel()
	{
		AsyncOperation asyncLoadLevel;
		asyncLoadLevel = SceneManager.LoadSceneAsync("lvl_Select_Menu");
		while (!asyncLoadLevel.isDone) 
		{
			GameManager.gm.loadedLevels = true;
			yield return null;
		}
	}

	public void LoadLevelSelect()
	{		
		StartCoroutine(LoadLevel());
		GameManager.gm.numUnlockedLevels += 1;
		GameManager.gm.startedLevel = false;
	}

	public void Quit()
	{
		Application.Quit();
	}
}
