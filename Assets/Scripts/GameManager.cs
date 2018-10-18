using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager gm;
	public List<GameObject> levels = new List<GameObject>();
	[HideInInspector] public int numUnlockedLevels = 0;
	// Use this for initialization
	void Start () {
		if (gm == null)
			gm = this;
		
		for(int i = 0; i < levels.Count; i++)
		{
			var spotlight = levels[i].transform.GetChild(0);
			spotlight.gameObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		ActivateSpotLights();
	}

	void ActivateSpotLights()
	{
		for(int i = 0; i < numUnlockedLevels; i++)
		{
			var spotlight = levels[i].transform.GetChild(0);
			spotlight.gameObject.SetActive(true);
		}
	}

	public void LoadLevel1()
	{
		Debug.Log("Level 1");
	}

	public void LoadLevel2()
	{
		if (numUnlockedLevels >= 2)
		{
			Debug.Log("Level 2");
			Debug.Log(numUnlockedLevels);
		}
	}

	public void LoadLevel3()
	{
		if (numUnlockedLevels >= 3)
		{
			Debug.Log("Level 3");
		}
	}
}
