using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager gm;
	public List<GameObject> levels = new List<GameObject>();
	public List<GameObject> level_buttons = new List<GameObject>();
	[HideInInspector] public int numUnlockedLevels;
	[HideInInspector] public bool loadedLevels = false;
	[HideInInspector] public bool startedLevel = false;
	[HideInInspector] public bool busyLoadingLevel = false;
	[HideInInspector] public LevelRequirements l_requirements = new LevelRequirements();

	// Use this for initialization
	void Awake () {
		if (gm == null)
			gm = this;
		else
			Destroy(gameObject);
		DontDestroyOnLoad(gameObject);
	}

	public void SavePlayerProgress()
	{
		PlayerPrefs.SetInt("numUnlockedLevels", numUnlockedLevels);
		PlayerPrefs.Save();
		Debug.Log(PlayerPrefs.GetInt("numUnlockedLevels"));
	}

	public void LoadLevelScene()
	{		
		for(int i = 0; i < 3; i++)
		{
			var spotlight = levels[i].transform.GetChild(0);
			spotlight.gameObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("escape") && !startedLevel)
			SceneManager.LoadScene("Menu");
		if (loadedLevels)
			GetLevels();
		if (levels.Count > 0 && !startedLevel)
			LoadLevelScene();
		if (level_buttons.Count > 0 && !startedLevel)
			InitButtons();
		if (!startedLevel)
			ActivateSpotLights();
		if (numUnlockedLevels == 4)
			PlayerPrefs.SetInt("numUnlockedLevels", 1);
	}

	void  InitButtons()
	{
		foreach (var button in level_buttons)
		{
			Button b = button.GetComponent<Button>();
			if (button.transform.tag == "lvl_1")
				b.onClick.AddListener(LoadLevel1);
			else if (button.transform.tag == "lvl_2")
				b.onClick.AddListener(LoadLevel2);
			else if (button.transform.tag == "lvl_3")
				b.onClick.AddListener(LoadLevel3);
		}
	}

	public void GetLevels()
	{
		levels.Clear();
		GameObject level = GameObject.FindWithTag("Level_Select");
		if (level != null && levels.Count == 0)
		{
			foreach (Transform child in level.transform)
			{
				if (child.tag == "lvl_1" || child.tag == "lvl_2" || child.tag == "lvl_3")
					levels.Add(child.gameObject);
			}
		}
		level_buttons.Clear();
		GameObject level_button = GameObject.FindWithTag("Level_Buttons");
		if (level_button != null && level_buttons.Count == 0)
		{
			foreach(Transform child in level_button.transform.GetChild(0))
			{
				if (child.tag == "lvl_1" || child.tag == "lvl_2" || child.tag == "lvl_3")
					level_buttons.Add(child.gameObject);
			}
		}
	}

	void ActivateSpotLights()
	{
		for(int i = 0; i < numUnlockedLevels; i++)
		{
			if (i < levels.Count)
			{
				var spotlight = levels[i].transform.GetChild(0);
				spotlight.gameObject.SetActive(true);
			}
		}
	}

	public void LoadLevel1()
	{
		startedLevel = true;
		l_requirements.ClearPrevious();
		l_requirements.min_y_rotations.Add(85f);
		l_requirements.max_y_rotations.Add(95f);
		if (!busyLoadingLevel)
		{
			StartCoroutine(LoadLevel("LoadScene", "lvl_1"));
			busyLoadingLevel = true;
		}
	}

	public void LoadLevel2()
	{
		l_requirements.ClearPrevious();
		if (numUnlockedLevels > 1)
		{
			startedLevel = true;
			l_requirements.min_y_rotations.Add(70f);
			l_requirements.max_y_rotations.Add(80f);
			l_requirements.min_x_rotations.Add(85f);
			l_requirements.max_x_rotations.Add(100f);
			if (!busyLoadingLevel)
			{
				StartCoroutine(LoadLevel("LoadScene", "lvl_2"));
				busyLoadingLevel = true;
			}
		}
	}

	public void LoadLevel3()
	{
		l_requirements.ClearPrevious();
		if (numUnlockedLevels >= 2)
		{
			//First Object
			l_requirements.min_y_rotations.Add(80f);
			l_requirements.max_y_rotations.Add(90f);
			//Second Object
			l_requirements.min_y_positions.Add(15.8f);
			l_requirements.max_y_positions.Add(16.2f);
			l_requirements.min_y_rotations.Add(90f);
			l_requirements.max_y_rotations.Add(108f);
			if (!busyLoadingLevel)
			{
				StartCoroutine(LoadLevel("LoadScene", "lvl_3"));
				busyLoadingLevel = true;
			}
		}
	}

	IEnumerator LoadLevel(string name, string lvl)
	{
		AsyncOperation async = SceneManager.LoadSceneAsync(name);

        while (!async.isDone) 
		{
            yield return null;
		}
		LoadingScene.ls.LoadScene(lvl);
	}
}
