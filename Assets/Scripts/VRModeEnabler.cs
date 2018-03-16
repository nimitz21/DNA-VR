using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRModeEnabler : MonoBehaviour {

	private const string VR_DEVICE_NAME = "cardboard";

	IEnumerator Start () {
		XRSettings.LoadDeviceByName (VR_DEVICE_NAME);
		yield return null;
		XRSettings.enabled = true;
	}

}
