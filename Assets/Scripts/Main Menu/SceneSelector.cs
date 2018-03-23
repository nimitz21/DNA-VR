using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class SceneSelector : MonoBehaviour {

	public void LoadScene (string sceneName) {
		SceneManager.LoadScene (sceneName, LoadSceneMode.Single);
	}

}
