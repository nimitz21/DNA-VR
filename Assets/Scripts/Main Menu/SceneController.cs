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

	[SerializeField]
	private GameObject sceneSelect;
	[SerializeField]
	private GameObject prologue;

	public void LoadScene (string sceneName) {
		SceneManager.LoadScene (sceneName, LoadSceneMode.Single);
	}

	public void ShowPrologue () {
		sceneSelect.SetActive (false);
		prologue.SetActive (true);
		prologue.GetComponent <Prologue> ().Open ();
	}
}
