using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator LoadLevel()
	{
		AsyncOperation asyncLoadLevel;
		asyncLoadLevel = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
		while (!asyncLoadLevel.isDone) 
		{
			GameManager.gm.loadedLevels = true;
			yield return null;
		}
	}

	public void LoadLevelSelect()
	{		
		StartCoroutine(LoadLevel());
		GameManager.gm.completed_levels.Add("lvl_1");
	}

	public void LoadTest()
	{
		StartCoroutine(LoadLevel());
		GameManager.gm.numUnlockedLevels = 3;
		GameManager.gm.completed_levels.Add("lvl_1");
		GameManager.gm.completed_levels.Add("lvl_2");
		GameManager.gm.completed_levels.Add("lvl_3");
	}

	public void Quit()
	{
		Application.Quit();
	}
}
