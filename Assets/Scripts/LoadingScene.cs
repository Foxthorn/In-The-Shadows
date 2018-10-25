using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour {

	public static LoadingScene ls;

	// Use this for initialization
	void Start () {
		if (ls == null)
			ls = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localScale.x < 1f)
			transform.localScale = new Vector3(transform.localScale.x + 0.01f, transform.localScale.y, transform.localScale.z);
	}

	public void LoadScene(string name)
	{
		StartCoroutine(LoadLevel(name));
	}

	IEnumerator LoadLevel(string name)
	{
		yield return new WaitForSeconds(3);

		AsyncOperation async = SceneManager.LoadSceneAsync(name);

        while (!async.isDone) 
		{
		    yield return null;
		}
	}
}
