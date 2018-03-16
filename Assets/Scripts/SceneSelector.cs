using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class SceneSelector : MonoBehaviour {

	private const string DEFAULT_SCENE = "Circus";
	private string currentSceneName;

	void Start () {
		currentSceneName = DEFAULT_SCENE;
	}

	public void LoadSelectedScene () {
		SceneManager.LoadScene (currentSceneName, LoadSceneMode.Single);
	}

	public void SelectScene (string sceneName) {
		currentSceneName = sceneName;
	}

}
