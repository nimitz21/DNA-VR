using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class SceneController : MonoBehaviour {

	private static SceneController instance;
	public static SceneController Instance {
		get {
			if (instance == null) {
				instance = FindObjectOfType <SceneController> ();
			}
			return instance;
		}
	}

	public void LoadScene (string sceneName) {
		SceneManager.LoadScene (sceneName, LoadSceneMode.Single);
	}

}
