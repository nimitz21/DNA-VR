using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VR;

public class chapterSelectController : MonoBehaviour {

	private const string VR_DEVICE_NAME = "cardboard";
	private const string CHAPTER_SELECT_SCENE = "Chapter Select";
	private const string TITTLE_SCREEN_SCENE = "Title Screen";
	private const string CHAPTER_1_SCENE = "Circus";

	private IEnumerator runInVRMode (string scene) {
		VRSettings.LoadDeviceByName (VR_DEVICE_NAME);
		yield return null;
		VRSettings.enabled = true;
		yield return new WaitForSeconds(0.1f);
		SceneManager.LoadScene (scene, LoadSceneMode.Single);
	}

	private void goToScene (string scene) {
		if (SceneManager.GetActiveScene ().name == CHAPTER_SELECT_SCENE) {
			StartCoroutine (runInVRMode (scene));
		} else {
			SceneManager.LoadScene (scene, LoadSceneMode.Single);
		}
	}

	public void goToTitleScreen () {
		goToScene (TITTLE_SCREEN_SCENE);
	}

	public void goToChapter1 () {
		goToScene (CHAPTER_1_SCENE);
	}

}