using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRController : MonoBehaviour {

	private static VRController instance;
	public static VRController Instance {
		get {
			if (instance == null) {
				instance = FindObjectOfType <VRController> ();
			}
			return instance;
		}
	}


	private const string NO_VR_DEVICE_NAME = "none";
	private const string VR_DEVICE_NAME = "cardboard";
	private const string HOME_SCENE_NAME = "Home";

	IEnumerator Start () {
		XRSettings.LoadDeviceByName (VR_DEVICE_NAME);
		yield return null;
		XRSettings.enabled = true;
	}

	public IEnumerator BackToMainMenu () {
		XRSettings.LoadDeviceByName (NO_VR_DEVICE_NAME);
		yield return null;
		XRSettings.enabled = false;
		SceneController.Instance.LoadScene (HOME_SCENE_NAME);
	}

	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			StartCoroutine (BackToMainMenu ());
		}
	}

}
