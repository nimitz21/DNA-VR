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

	private static bool created = false;

	public bool isJustLaunched;

	void Awake () {
		if (!created) {
			DontDestroyOnLoad (gameObject);
			created = true;
		} else {
			DestroyObject (gameObject);
		}
	}

	void Start () {
		isJustLaunched = true;
	}

	public void LoadScene (string sceneName) {
		SceneManager.LoadScene (sceneName, LoadSceneMode.Single);
	}
		

}
